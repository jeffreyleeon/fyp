using UnityEngine;
using System.Collections;
using Leap;

[RequireComponent(typeof(PhotonView))]
public class ShootingController : MonoBehaviour {

	[Tooltip("Prefab of bullet to be spawned")]
	public GameObject bullet;

    [Tooltip("Bullet's custom rotation during init")]
    public Quaternion bulletRotation = Quaternion.identity;

	[Tooltip("Number of bullets to be spawned per second")]
	public int numOfBulletPerSecond;

	private HandStore handStore;

	void Start () {
		handStore = HandStore.GetInstance ();

		float rate = 1.0f / numOfBulletPerSecond;
		InvokeRepeating ("SpawnBullet", 0, rate);
	}

	/// <summary>
	/// Spawns bullet by passing in handmod
	/// </summary>
	private void SpawnBullet() {
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
		if (!handStore.IsOpenHand (handModel)) {
			// Returning if hand is not opened
			return;
		}
		Vector3 position = handModel.GetPalmPosition();
		Vector3 palmNormal = handModel.GetPalmNormal();
        GameObject bulletGO = PhotonNetwork.Instantiate(bullet.name, (position + palmNormal * 2), bulletRotation, 0) as GameObject;
		bulletGO.layer = LayerMask.NameToLayer("Bullet");
		// Place the bullet a bit in front of the palm
		//bulletGO.transform.position = position + palmNormal * 2;
		Rigidbody rigidBody = bulletGO.GetComponent<Rigidbody> ();
		rigidBody.velocity = palmNormal * 100;
	}


}
