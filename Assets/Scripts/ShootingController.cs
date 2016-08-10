using UnityEngine;
using System.Collections;
using Leap;

public class ShootingController : MonoBehaviour {

	[Tooltip("Prefab of bullet to be spawned")]
	public Rigidbody bullet;

	private HandStore handStore;

	void Start () {
		handStore = HandStore.GetInstance ();
	}

	void Update () {
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
		Quaternion rotation = new Quaternion (0, 0, 0, 0);
		Instantiate (bullet, position, rotation);
	}
}
