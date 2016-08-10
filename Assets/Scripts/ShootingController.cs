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
			if (handStore.IsOpenHand (hand)) {
				Vector3 controllerPos = GameObject.FindGameObjectWithTag ("LeapMotionController").transform.position;
				print ("=====ok");
				//Debug.Log ((LeapUnityUtil.toUnityvector3(hand.PalmPosition.ToUnityScaled() * 5) + controllerPos).ToString());
//				Instantiate (bullet, (LeapUnityUtil.toUnityvector3(hand.PalmPosition.ToUnityScaled() * 10) + controllerPos), new Quaternion(0,0,0,0));
			}
		}
	}
}
