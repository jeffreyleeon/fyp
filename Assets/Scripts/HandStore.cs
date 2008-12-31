using UnityEngine;
using System.Collections;
using Leap;

public sealed class HandStore{

	private static HandStore instance = new HandStore();
	private static GameObject leapMotionController;
	private HandList allHands;
	private const int extendFingerThreshold = 4;

	private int handNum {
		get {
			return allHands.Count;
		}
	}

	private HandStore(){
		allHands = new HandList();
		leapMotionController = ObjectStore.FindLeapMotionController ();
	}

	public static HandStore GetInstance(){
		return instance;
	}

	// set hands
	public void SetHands(Frame leapFrame){
		allHands = leapFrame.Hands;
	}

	public HandList GetHands (){
		return allHands;
	}

	// check if hand is open
	public bool IsOpenHand(Hand hand){
		int extendCount = 0;
		foreach (Finger finger in hand.Fingers) {
			if (finger.IsExtended) {
				extendCount++;
			}
		}
		if (extendCount >= extendFingerThreshold) {
			return true;
		}
		return false;
	}

	// check if hand appear
	public bool IsHandAppear(){
		return handNum != 0;
	}

	public Vector3 GetPalmPositionInWorld (Hand hand) {
		Vector3 unityPosition = hand.PalmPosition.ToUnityScaled ();
		Vector3 worldPosition = leapMotionController.transform.TransformPoint (unityPosition);
		return worldPosition;
	}

	public Vector3 GetPalmNormalDirection (Hand hand) {
		Vector direction = hand.Direction;
		return new Vector3 (direction.x, direction.y, direction.z) * -1;
	}
}
