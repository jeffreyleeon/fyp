using UnityEngine;
using System.Collections;
using Leap;
using UnityEngine.UI;
using System.IO;
using MagicalFX;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(SceneWeaponsList))]
public class ShootingController : Photon.MonoBehaviour {

	[Tooltip("Prefab of bullet to be spawned")]
	public GameObject bulletPrefab;

    [Tooltip("Bullet's custom rotation during init")]
    public Quaternion bulletRotation = Quaternion.identity;

	[Tooltip("Number of bullets to be spawned per second")]
	public int numOfBulletPerSecond;

	private HandStore handStore;

	[Tooltip("A mutex lock to prevent calling multiple change weapon at the same time")]
	private bool changingWeaponMutexLock = false; // True is changing weapon, False is not changing weapon
	private int mutexLockTimer = 3; // A timer to unlock after weapon is changed

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
		SetupOnDirectionBullet (bulletGO, bulletDirection);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();
		bullet.SetOwner (owner);
		bullet.gameObject.layer = LayerMask.NameToLayer("Bullet");
		// Place the bullet a bit in front of the palm
		Rigidbody rigidBody = bullet.GetComponent<Rigidbody> ();
		rigidBody.velocity = bulletDirection * bullet.speed;
	}

	/// <summary>
	/// Mgical Library directional bullets required setting transform.forward [Jeffrey]
	/// </summary>
	void SetupOnDirectionBullet (GameObject bulletGO, Vector3 bulletDirection) {
		FX_Position fx = bulletGO.GetComponent<FX_Position> ();
		if (fx && fx.Mode == SpawnMode.OnDirection) {
			fx.transform.forward = bulletDirection;
		}
	}


	/// <summary>
	/// Check if the user is intended to change weapon
	/// </summary>
	private void CheckChangeWeapon() {
		// print ("==============should change " + handStore.IsHandSwipingAndClosed ());
		if (!handStore.IsHandSwipingAndClosed () || changingWeaponMutexLock == true) {
			return;
		}
		changingWeaponMutexLock = true;
		// Do change weapon logic
		ChangeWeapon ();
		// Release mutex lock
		StartCoroutine (UnlockChangeWeaponMutex());
	}

	private void ChangeWeapon () {
		Player player = ObjectStore.FindMyPlayer ();
		if (!player) {
			Debug.Log ("/FYP/ShootingController/ChangeWeapon: player is null");
			return;
		}
		WeaponManager.WeaponType currentWeaponType = player.GetWeaponBehv ().WeaponType ();
		// Get scene weapons list
		WeaponManager.WeaponType[] weaponsList = GetWeaponsList ();
		// Update to the next weapon
		int index = System.Array.IndexOf (weaponsList, currentWeaponType);
		index = (index + 1) % weaponsList.Length;
		player.SetWeaponBehv (weaponsList [index]);
	}

	public void UpdateWeaponIcon (string filePath) {
		GameObject[] bulletTypeImages = ObjectStore.FindBulletTypeImages ();
		foreach (GameObject imageGO in bulletTypeImages) {
			RawImage image = (RawImage)imageGO.GetComponent<RawImage>();

			string _filePath = filePath;
			if (!File.Exists (filePath)) {
				_filePath = WeaponManager.defaultWeaponIconFilePath;
			}
			byte[] fileData = File.ReadAllBytes(_filePath);
			Texture2D texture = new Texture2D(128, 128);
			texture.LoadImage (fileData);
			image.texture = (Texture) texture;
		}
	}

	private WeaponManager.WeaponType[] GetWeaponsList () {
		SceneWeaponsList weaponsListComponent = GetComponent<SceneWeaponsList> ();
		WeaponManager.WeaponType[] sceneWeaponsList;
		if (weaponsListComponent) {
			sceneWeaponsList = weaponsListComponent.weaponsList;
		} else {
			sceneWeaponsList = new WeaponManager.WeaponType[] { WeaponManager.WeaponType.Bullet };
		}
		return sceneWeaponsList;
	}

	private IEnumerator UnlockChangeWeaponMutex () {
		yield return new WaitForSeconds (mutexLockTimer);
		changingWeaponMutexLock = false;
	}

}
