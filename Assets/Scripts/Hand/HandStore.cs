using UnityEngine;
using System.Collections;
using Leap;

public sealed class HandStore{

	private static HandStore instance = new HandStore();
	private static GameObject leapMotionController;
	private HandModel[] allHandModels;
	private const int extendFingerThreshold = 4;

	public int handNum {
		get {
			return allHandModels.Length;
		}
	}

	private HandStore(){
		allHandModels = new HandModel[] {};
		leapMotionController = ObjectStore.FindLeapMotionController ();
	}

	public static HandStore GetInstance(){
		return instance;
	}

	// set hands
	public void SetHands(HandModel[] allGraphicHands){
		allHandModels = new HandModel[allGraphicHands.Length];
		allGraphicHands.CopyTo(allHandModels, 0);
	}

	public HandModel[] GetHands (){
		return allHandModels;
	}

	// check if hand is open
	public bool IsOpenHand(HandModel handModel){
		int extendCount = 0;
		Hand leapHand = handModel.GetLeapHand ();
		foreach (Finger finger in leapHand.Fingers) {
			if (finger.IsExtended) {
				extendCount++;
			}
		}
		if (extendCount >= extendFingerThreshold) {
			return true;
		}
		return false;
	}

	// check if hand is closed
	public bool IsCloseHand(HandModel handModel) {
		int extendCount = 0;
		Hand leapHand = handModel.GetLeapHand ();
		foreach (Finger finger in leapHand.Fingers) {
			if (finger.IsExtended) {
				extendCount++;
			}
		}
		if (extendCount <= 1) {
			return true;
		}
		return false;
	}

	public float PalmVelocity (HandModel handmod) {
		Hand leapHand = handmod.GetLeapHand ();
		Vector handSpeedVector = leapHand.PalmVelocity;
		return handSpeedVector.Magnitude;
	}

	// check if hand appear
	public bool IsHandAppear(){
		return handNum != 0;
	}

	// check if thumb is touching index finger
	[System.Obsolete("HandStore.AreThumbsTouchingIndexFinger function is deprecated")]
	public bool AreThumbsTouchingIndexFinger () {
		HandModel[] handModels = new HandModel[handNum];
		allHandModels.CopyTo (handModels, 0);
		bool isTouching = false;
		foreach (HandModel handmod in handModels) {
			Hand leapHand = handmod.GetLeapHand ();
			isTouching = IsThumbTouchingIndexFinger (leapHand);
		}
		return isTouching;
	}

	[System.Obsolete("HandStore.IsThumbTouchingIndexFinger function is deprecated")]
	private bool IsThumbTouchingIndexFinger (Hand hand) {
		bool isTouching = false;
		Finger thumb = hand.Fingers [0];
		Finger index = hand.Fingers [1];
		// From inside to outside: TYPE_METACARPAL, TYPE_PROXIMAL, TYPE_INTERMEDIATE, TYPE_DISTAL
		Bone thumbDistal = thumb.Bone (Bone.BoneType.TYPE_DISTAL);
		Bone indexDistal = index.Bone (Bone.BoneType.TYPE_DISTAL);
		Bone indexIntermediate = index.Bone (Bone.BoneType.TYPE_INTERMEDIATE);
		Bone indexProximal = index.Bone (Bone.BoneType.TYPE_PROXIMAL);

		float distalDistance = thumbDistal.Center.DistanceTo(indexDistal.Center);
		float intermediateDistance = thumbDistal.Center.DistanceTo(indexIntermediate.Center);
		float proximalDistance = thumbDistal.Center.DistanceTo(indexProximal.Center);

		float minDistance;
		minDistance = Mathf.Min (distalDistance, intermediateDistance);
		minDistance = Mathf.Min (minDistance, proximalDistance);

		return isTouching;
	}

	public bool IsHandSwipingAndClosed () {
		bool isSwiping = false;
		HandModel[] handModels = new HandModel[handNum];
		allHandModels.CopyTo (handModels, 0);
		foreach (HandModel handmod in handModels) {
			isSwiping = PalmVelocity (handmod) > 900f && IsCloseHand (handmod);
		}
		return isSwiping;
	}

	/*
	public Vector3 GetPalmPosition (HandModel handmod) {
		return handmod.GetPalmPosition();
	
	}

	public Vector3 GetPalmNormalDirection (HandModel handmod) {
		return handmod.GetPalmNormal();
	}
	*/
}
