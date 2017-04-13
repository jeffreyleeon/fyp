using UnityEngine;
using System.Collections;
using FYP.Score;

public class Enemy : HittableObject {


	public int attack = 10;

	#region movement param

	private Transform track;
	[Tooltip("Game Object that the enemies move toward")]
	public GameObject trackObj = null;
	[Tooltip("Prefab of the score text")]
	public GameObject scoreText;
	[Tooltip("Moving speed of enemy")]
	public float moveSpeed = 3f;
	[Tooltip("Height that the enemy jump")]
	public int jumpingForce = 150;
	[Tooltip("Boundary of X-cor that an enemy to destroy")]
	public int minX = -40;
	[Tooltip("Boundary of X-cor that an enemy to destroy")]
	public int maxX = 40;
	[Tooltip("Boundary of Y-cor that an enemy to destroy")]
	public int minY = -12;
	[Tooltip("Boundary of Y-cor that an enemy to destroy")]
	public int maxY = 40;
	[Tooltip("Boundary of Z-cor that an enemy to destroy")]
	public int minZ = 0;
	[Tooltip("Boundary of Z-cor that an enemy to destroy")]
	public int maxZ = 40;
	[Tooltip("Audio of enemy being hit")]
	public AudioClip hitAudio;
	[Tooltip("Is enemy in idle state")]
	public bool isIdle = false;
	[Tooltip("Is enemy a boss")]
	public bool isBoss = false;

	#endregion

	// Use this for initialization
	virtual public void Start () {
		if (trackObj == null) {
			trackObj = GameObject.Find("Track");
		}
		if (trackObj != null) {
			track = trackObj.transform;
		}
		SetHitBehv (HitType.Normal);

		if (IsBoss ()) {
			float currentHP = (float)GetCurrentHealth ();
			ObjectStore.SetBossMaxHP (currentHP);
			ObjectStore.SetBossCurrentHP (currentHP);
		}
	}


	// Update is called once per frame
	virtual public void Update () {
		bool isActive = !isIdle;
		if (this.photonView.isMine && isActive) {
			Move ();
		}

		if (IsBoss ()) {
			int currentHP = GetCurrentHealth ();
			ObjectStore.SetBossCurrentHP (currentHP);
		}
	}


	/// <summary>
	/// Move this object.
	/// </summary>
	virtual protected void Move() {
		bool outOfBound = transform.position.x < minX || transform.position.x > maxX ||
			transform.position.y < minY || transform.position.y > maxY ||
			transform.position.z < minZ || transform.position.z > maxZ;
		if (outOfBound) {
			this.Kill ();
		} else {
			float move = moveSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, track.position, move);
		}
	}

	/// <summary>
	/// when enemy collide with bullet.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == ObjectStore.GetBulletTag ()) {
			PlayHitSound ();
			Bullet b = collision.gameObject.GetComponent<Bullet> ();
			hitBehv.HitBy (b.Attack);
			if (this.IsDead()) {
				if (b.IsOwnBy(PhotonNetwork.player.name)) {
					Scoreboard.AddLocalPlayerScore (ObjectStore.GetScoreByTag (this.tag));
				}
				Debug.Log ("Local player score: " + Scoreboard.GetLocalPlayerScore());
				this.Kill ();
			}
		}
	}

	void PlayHitSound () {
		if (hitAudio != null) {
			AudioSource audio = GetComponent<AudioSource>();
			audio.PlayOneShot(hitAudio);
		}
	}

	bool IsDead(){
		return (this.GetCurrentHealth () <= 0);
	}

	public bool IsBoss () {
		return isBoss;
	}

	public virtual void RunDieAnimation () {}

	public virtual void Kill() {
		StartCoroutine (BaseClassKill ());

		DisableMovementsAndCollisions ();
		RunDieAnimation ();
		if (isBoss) {
			GameManager gm = ObjectStore.FindGameManager ().GetComponent<GameManager> ();
			gm.PlayerWin ();
		}
		if (GetCurrentHealth () <= 0) {
			//not out of bound
			DisplayScoreText ();
		}
		StatisticsStore.GetInstance ().IncrementEnemyKilled ();
	}
	IEnumerator BaseClassKill () {
		yield return new WaitForSeconds (2);
		base.Kill ();
	}

	private void DisableMovementsAndCollisions () {
		isIdle = true;
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		rb.detectCollisions = false;
	}

	private void DisplayScoreText () {
		if (scoreText == null) {
			return;
		}
		GameObject textObject = (GameObject)Instantiate(scoreText, transform.position, Quaternion.identity);
		TextMesh textMesh = textObject.GetComponent<TextMesh> ();
		textMesh.text = "+" + ObjectStore.GetScoreByTag (this.tag).ToString();
	}
}
