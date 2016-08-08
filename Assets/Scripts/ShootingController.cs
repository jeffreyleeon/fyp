using UnityEngine;
using System.Collections;
using Leap;

public class ShootingController : MonoBehaviour {
		
	public Rigidbody bullet;
	Vector3 gal;
	// Update is called once per frame
	void Update () {
		HandStore handstore = HandStore.GetInstance ();
		if (handstore.IsHandAppear ()) {
			HandList hands = handstore.GetHands();
			foreach (Hand hand in hands) {
				if (handstore.IsOpenHand (hand)) {
					Vector3 controllerPos = GameObject.FindGameObjectWithTag ("LeapMotionController").transform.position;
					//Debug.Log ((LeapUnityUtil.toUnityvector3(hand.PalmPosition.ToUnityScaled() * 5) + controllerPos).ToString());
					Instantiate (bullet, (LeapUnityUtil.toUnityvector3(hand.PalmPosition.ToUnityScaled() * 10) + controllerPos), new Quaternion(0,0,0,0));

					}
			}
		}
	}
}
