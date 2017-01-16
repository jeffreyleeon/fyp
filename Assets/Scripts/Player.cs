using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : HittableObject {
	
	#region public param
	public int playerId;
	#endregion 


	#region private param
	private IWeapon weaponBehv;
	private string userName;
	#endregion

	void Start(){
		if (this.photonView.isMine) {
			SetUserName ();
			PhotonNetwork.player.SetScore (0);
			SetWeaponBehv (WeaponManager.WeaponType.Bullet);
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


	public string GetUserName(){
		return userName;
	}

	public IWeapon GetWeaponBehv () {
		return weaponBehv;
	}

	public void SetWeaponBehv (WeaponManager.WeaponType newWeapon){
		if (newWeapon == null) {
			return;
		}
		if (weaponBehv != null) {
			Destroy (gameObject.GetComponent(weaponBehv.GetType()));
		}

		switch (newWeapon) {
			case WeaponManager.WeaponType.Bullet:
				weaponBehv = (IWeapon) gameObject.AddComponent<BulletBehv>();
				break;
			case WeaponManager.WeaponType.Knife:
				weaponBehv = (IWeapon) gameObject.AddComponent<KnifeBehv>();
				break;
			case WeaponManager.WeaponType.LightingShot:
				weaponBehv = (IWeapon) gameObject.AddComponent<LightingShotBehv>();
				break;
			case WeaponManager.WeaponType.FireFissure:
				weaponBehv = (IWeapon) gameObject.AddComponent<FireFissureBehv>();
				break;
			case WeaponManager.WeaponType.DarkMissile:
				weaponBehv = (IWeapon) gameObject.AddComponent<DarkMissileBehv>();
				break;
			case WeaponManager.WeaponType.FireRock:
				weaponBehv = (IWeapon) gameObject.AddComponent<FireRockBehv>();
				break;
			case WeaponManager.WeaponType.IceWave:
				weaponBehv = (IWeapon) gameObject.AddComponent<IceWaveBehv>();
				break;
			case WeaponManager.WeaponType.FireBurn:
				weaponBehv = (IWeapon) gameObject.AddComponent<FireBurnBehv>();
				break;
			case WeaponManager.WeaponType.LightingFissure:
				weaponBehv = (IWeapon) gameObject.AddComponent<LightingFissureBehv>();
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
		

	#endregion

	void OnCollisionEnter(Collision collision){
		//TODO: should check photonview.isMine? could reduce some computation
		if (collision.gameObject.tag == ObjectStore.GetEnemyTag ()) {
			Enemy enemy = collision.gameObject.GetComponent<Enemy> ();
			hitBehv.HitBy (enemy.attack);
		}
		if (GetCurrentHealth () == 0 && userName == PhotonNetwork.player.name) {
			GameManager gm = ObjectStore.FindGameManager ().GetComponent<GameManager> ();
			gm.PlayerDie ();
		}
	}
		
		
}
