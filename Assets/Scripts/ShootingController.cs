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
		HandList hands = handStore.GetHands();
		foreach (Hand hand in hands) {
			SpawnBulletFromHand (hand);
		}
	}

	private void SpawnBulletFromHand(Hand hand) {
		if (!handStore.IsOpenHand (hand)) {
			// Returning if hand is not opened
			return;
		}
		Vector3 position = handStore.GetPalmPositionInWorld (hand);
		Vector3 palmNormalDirection = handStore.GetPalmNormalDirection (hand);
		GameObject bulletGO = Instantiate (bullet) as GameObject;
		bulletGO.layer = LayerMask.NameToLayer("Bullet");
		// Place the bullet a bit in front of the palm
		bulletGO.transform.position = position + palmNormalDirection * 2;
		Rigidbody rigidBody = bulletGO.GetComponent<Rigidbody> ();
		rigidBody.velocity = palmNormalDirection * 100;
	}
}
