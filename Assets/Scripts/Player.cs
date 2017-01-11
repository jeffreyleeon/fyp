using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : HittableObject {
	
	#region public param
	public int playerId;
	public enum WeaponType{
		Bullet,
		Knife
	}
	#endregion 


	#region private param
	private IWeapon weaponBehv;
	private string userName;
	private int score;
	#endregion

	void Start(){
		if (this.photonView.isMine) {
			SetUserName ();
			PhotonNetwork.player.SetScore (0);
			SetWeaponBehv (WeaponType.Bullet);
			SetHitBehv (HitType.Normal);
		} else {
			userName = this.photonView.owner.name;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		MovementControl ();

	}


	#region public method
	public int GetScore(){
		return score;
	}

	public void AddScore(int mark){
		score += mark;
	}

	public string GetUserName(){
		return userName;
	}

	public void SetWeaponBehv (WeaponType newWeapon){
		if (newWeapon == null) {
			return;
		}
		if (weaponBehv != null) {
			Destroy (gameObject.GetComponent(weaponBehv.GetType()));
		}

		switch (newWeapon) {
			case WeaponType.Bullet:
				weaponBehv = (IWeapon) gameObject.AddComponent<BulletBehv>();
				break;
			case WeaponType.Knife:
				weaponBehv = (IWeapon) gameObject.AddComponent<KnifeBehv>();
				break;
		}
		weaponBehv.SetShootingController ();

	}
	#endregion


	#region private method
	private void SetUserName(){
		// TODO: get username from UI
		userName = "Default" + Random.Range(1,100);
		PhotonNetwork.player.name = userName;
	}

	/// <summary>
	/// Move Player position, just for testing
	/// </summary>
	private void MovementControl(){
		//control movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody> ();
		rigidbody.velocity = movement * 10.0f;

		if (Input.GetKey(KeyCode.Space)){
			Debug.Log ("Input Key: Space Down");
			rigidbody.velocity = rigidbody.velocity + (Vector3.up * 50 * Time.fixedDeltaTime);
		}else if(Input.GetKey(KeyCode.I)){
			// debug for score scene
			GameObject trinus = ObjectStore.FindTrinus();
			trinus.transform.parent = null;
			ChangeScene.ChangeToScene(ChangeScene.SCORE_SCENE);
		}
	}

	private bool allPlayerDie(){
		GameObject[] allPlayers = ObjectStore.FindAllPlayers ();
		foreach (GameObject plyrGO in allPlayers) {
			Player plyr = plyrGO.GetComponent<Player> ();
			if (plyr.GetCurrentHealth() > 0) {
				return false;
			}
		}
		return true;
	}

	#endregion

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == ObjectStore.GetEnemyTag ()) {
			Enemy enemy = collision.gameObject.GetComponent<Enemy> ();
			hitBehv.HitBy (enemy.attack);
			if (GetCurrentHealth () == 0 && userName == PhotonNetwork.player.name) {
				StartCoroutine ("activateDeath");
			}
		}
	}

	IEnumerator activateDeath(){
		GameObject deathPanel = GameObject.Find("Death");
		deathPanel.GetComponent<Image> ().fillCenter = true;
		deathPanel.GetComponent<Image> ().CrossFadeColor (Color.red, 1.0f, false, false);
		yield return new WaitForSeconds (1.0f);
		deathPanel.GetComponent<Image> ().CrossFadeColor (Color.black, 0.5f, false, false);
		yield return new WaitForSeconds (0.5f);
		deathPanel.GetComponent<Image> ().CrossFadeAlpha (150.0f, 1.0f, false);
		yield return new WaitForSeconds (1.0f);

		GameObject trinus = ObjectStore.FindTrinus();
		trinus.transform.parent = null;
		if (allPlayerDie()) {
			this.photonView.RPC ("BroadcastChangeToScene", PhotonTargets.AllViaServer, ChangeScene.SCORE_SCENE);
		} else {
			deathPanel.GetComponent<Image> ().CrossFadeAlpha (0f, 1.0f, false);
			trinus.transform.position = new Vector3 (0, 10, -10);
			this.GetComponent<MeshRenderer> ().enabled = false;
			this.GetComponent<CapsuleCollider> ().enabled = false;
		}
	}

	[PunRPC]
	public void BroadcastChangeToScene(int sceneIndex) {
		ChangeScene.ChangeToScene (sceneIndex);
	}
		
		
}
