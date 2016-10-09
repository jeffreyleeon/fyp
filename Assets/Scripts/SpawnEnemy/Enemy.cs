using UnityEngine;
using System.Collections;

public class Enemy : HittableObject {




	#region movement param

	private Transform track;
	[Tooltip("Game Object that the enemies move toward")]
	public GameObject trackObj = null;
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
	public int minZ = 2;
	[Tooltip("Boundary of Z-cor that an enemy to destroy")]
	public int maxZ = 40;
	[Tooltip("Audio of enemy being hit")]
	public AudioClip hitAudio;

	#endregion

	// Use this for initialization
	void Start () {
		if (trackObj == null) {
			trackObj = GameObject.Find("Track");
		}
		track = trackObj.transform;
	}


	// Update is called once per frame
	virtual protected void Update () {
		if (this.photonView.isMine) {
			Move ();
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
			HitBy (b.Attack);
			if (this.GetCurrentHealth () == 0) {
				if (b.owner == PhotonNetwork.player.name) {
					PhotonNetwork.player.AddScore (ObjectStore.GetScoreByTag (this.tag));
				}
				Debug.Log ("Local player score: " + PhotonNetwork.player.GetScore ());
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
}
