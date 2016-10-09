using UnityEngine;
using System.Collections;
using Leap;

[RequireComponent(typeof(PhotonView))]
public class AutoShooter : Photon.MonoBehaviour {
	[Tooltip("Activate autoshooter")]
	public bool active = false;

	[Tooltip("Prefab of bullet to be spawned")]
	public GameObject bulletPrefab;

	[Tooltip("Bullet's custom rotation during init")]
	public Quaternion bulletRotation = Quaternion.identity;

	[Tooltip("Number of bullets to be spawned per second")]
	public int numOfBulletPerSecond;



	void Start () {
		if (active) {
			float rate = 1.0f / numOfBulletPerSecond;
			InvokeRepeating ("Shoot", 0, rate);
			Debug.Log ("autoshooter started, rate: " + rate);
		}
	}


	 
	/// <summary>
	/// auto-shooting bullet to Z direction
	/// </summary>
	private void Shoot() {
		if (PhotonNetwork.inRoom) {
			this.photonView.RPC ("SpawnBullet", PhotonTargets.AllViaServer, PhotonNetwork.player.name, "TestingBullet", new Vector3(0, -8, 0), bulletRotation, new Vector3 (0, 0, 200));
		}
	}



	[PunRPC]
	void SpawnBullet(string owner, string bulletPrefabPath, Vector3 bulletPosition, Quaternion bulletRotation, Vector3 bulletVelocity){
		GameObject bulletPrefab = Resources.Load (bulletPrefabPath) as GameObject;
		GameObject bulletGO = Instantiate (bulletPrefab, bulletPosition, bulletRotation) as GameObject;
		Bullet bullet = bulletGO.GetComponent<Bullet> ();
		bullet.SetOwner (owner);
		bullet.gameObject.layer = LayerMask.NameToLayer("Bullet");
		// Place the bullet a bit in front of the palm
		Rigidbody rigidBody = bullet.GetComponent<Rigidbody> ();
		rigidBody.velocity = bulletVelocity;
	}



}
