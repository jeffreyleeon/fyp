using UnityEngine;
using System.Collections;
using Leap;

[RequireComponent(typeof(PhotonView))]
public class ShootingController : Photon.MonoBehaviour {

	[Tooltip("Prefab of bullet to be spawned")]
	public GameObject bulletPrefab;

    [Tooltip("Bullet's custom rotation during init")]
    public Quaternion bulletRotation = Quaternion.identity;

	[Tooltip("Number of bullets to be spawned per second")]
	public int numOfBulletPerSecond;

	private HandStore handStore;

	void Start () {
		handStore = HandStore.GetInstance ();
		Shoot ();
	}

	void Update () {
		CheckChangeWeapon ();
	}

	/// <summary>
	/// Shoot by passing in handmod
	/// </summary>
	private void Shoot() {
		float rate = 1.0f / numOfBulletPerSecond;
		Invoke ("Shoot", rate);
		if (!isActiveAndEnabled) {
			return;
		}
		HandModel[] handModels = new HandModel[handStore.handNum];
		handStore.GetHands ().CopyTo (handModels, 0);
		foreach (HandModel handmod in handModels) {
			SpawnBulletFromHand (handmod);
		}
	}


	/// <summary>
	/// Spwan bullet from palm normal
	/// </summary>
	/// <param name="handModel">Hand model.</param>
	private void SpawnBulletFromHand(HandModel handModel) {
		if (!handStore.IsOpenHand (handModel) || bulletPrefab == null) {
			// Returning if hand is not opened
			return;
		}
		Vector3 palmPosition = handModel.GetPalmPosition();
		Vector3 palmNormal = handModel.GetPalmNormal();
		Vector3 bulletDirection = palmNormal;
		//hard code prefab path
		if (NetworkManager.IsServerConnected) {
			this.photonView.RPC ("SpawnBullet", PhotonTargets.AllViaServer, PhotonNetwork.player.name, bulletPrefab.name, (palmPosition + palmNormal * 2), bulletRotation, bulletDirection);
		} else {
			SpawnBullet ("Default User", bulletPrefab.name, (palmPosition + palmNormal * 2), bulletRotation, bulletDirection);
		}
	}


	[PunRPC]
	void SpawnBullet(string owner, string bulletPrefabPath, Vector3 bulletPosition, Quaternion bulletRotation, Vector3 bulletDirection){
		GameObject bulletPrefab = Resources.Load (bulletPrefabPath) as GameObject;
		GameObject bulletGO = Instantiate (bulletPrefab, bulletPosition, bulletRotation) as GameObject;
		Bullet bullet = bulletGO.GetComponent<Bullet> ();
		bullet.SetOwner (owner);
		bullet.gameObject.layer = LayerMask.NameToLayer("Bullet");
		// Place the bullet a bit in front of the palm
		Rigidbody rigidBody = bullet.GetComponent<Rigidbody> ();
		rigidBody.velocity = bulletDirection * bullet.speed;
	}


	/// <summary>
	/// Check if the user is intended to change weapon
	/// </summary>
	private void CheckChangeWeapon() {
		print ("==============should change " + handStore.IsHandSwipingAndClosed ());
	}



}
