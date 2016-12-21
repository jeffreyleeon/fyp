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

	// check if hand appear
	public bool IsHandAppear(){
		return handNum != 0;
	}

	// check if thumb is touching index finger
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

	private bool IsThumbTouchingIndexFinger (Hand hand) {
		bool isTouching = false;
		foreach (Finger finger in hand.Fingers) {
			if (finger.Type != Finger.FingerType.TYPE_INDEX && finger.Type != Finger.FingerType.TYPE_THUMB) {
				continue;
			}
		}
		return isTouching;
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
