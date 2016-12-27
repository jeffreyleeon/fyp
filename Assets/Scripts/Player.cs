﻿using UnityEngine;
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
		SetUserName ();
		PhotonNetwork.player.SetScore (0);
		SetWeaponBehv(WeaponType.Bullet);
		SetHitBehv (HitType.Normal);
			
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

	#endregion

	public override void Kill ()
	{
		print ("zero health");
		GameObject trinus = ObjectStore.FindTrinus();
		trinus.transform.parent = null;
		base.Kill ();
		ChangeScene.ChangeToScene (ChangeScene.SCORE_SCENE);
	}

	void OnCollisionEnter(Collision collision){
		GameObject deathPanel = GameObject.Find("Death");
		deathPanel.GetComponent<Image> ().fillCenter = true;

		if (collision.gameObject.tag == ObjectStore.GetEnemyTag ()) {
			Enemy enemy = collision.gameObject.GetComponent<Enemy> ();
			hitBehv.HitBy (enemy.attack);
			if (GetCurrentHealth () == 0) {
				Kill ();
			}
		}

	}
		
}
