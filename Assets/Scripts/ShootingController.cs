using UnityEngine;
using System.Collections;
using Leap;

public class ShootingController : MonoBehaviour {

	[Tooltip("Prefab of bullet to be spawned")]
	public GameObject bullet;

	[Tooltip("Number of bullets to be spawned per second")]
	public int numOfBulletPerSecond;

	private HandStore handStore;

	void Start () {
		handStore = HandStore.GetInstance ();

		float rate = 1.0f / numOfBulletPerSecond;
		InvokeRepeating ("SpawnBullet", 0, rate);
	}

	private void SpawnBullet() {
		HandModel[] handmods = new HandModel[handStore.handNum];
		handStore.GetHands ().CopyTo (handmods, 0);
		foreach (HandModel handmod in handmods) {
			SpawnBulletFromHand (handmod);
		}
	}

	private void SpawnBulletFromHand(HandModel handMod) {
		if (!handStore.IsOpenHand (handMod)) {
			// Returning if hand is not opened
			return;
		}
		Vector3 position = handMod.GetPalmPosition();
		Vector3 palmNormal = handMod.GetPalmNormal();
		GameObject bulletGO = Instantiate (bullet) as GameObject;
		bulletGO.layer = LayerMask.NameToLayer("Bullet");
		// Place the bullet a bit in front of the palm
		bulletGO.transform.position = position + palmNormal * 2;
		Rigidbody rigidBody = bulletGO.GetComponent<Rigidbody> ();
		rigidBody.velocity = palmNormal * 100;
	}
}
