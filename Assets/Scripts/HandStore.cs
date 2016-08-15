using UnityEngine;
using System.Collections;
using Leap;

public sealed class HandStore{

	private static HandStore instance = new HandStore();
	private static GameObject leapMotionController;
	private HandModel[] allHandmods;
	private const int extendFingerThreshold = 4;

	public int handNum {
		get {
			return allHandmods.Length;
		}
	}

	private HandStore(){
		allHandmods = new HandModel[] {};
		leapMotionController = ObjectStore.FindLeapMotionController ();
	}

	public static HandStore GetInstance(){
		return instance;
	}

	// set hands
	public void SetHands(HandModel[] allGraphicHands){
		allHandmods = new HandModel[allGraphicHands.Length];
		allGraphicHands.CopyTo(allHandmods, 0);
	}

	public HandModel[] GetHands (){
		return allHandmods;
	}

	// check if hand is open
	public bool IsOpenHand(HandModel handmod){
		int extendCount = 0;
		Hand leapHand = handmod.GetLeapHand ();
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

	/*
	public Vector3 GetPalmPosition (HandModel handmod) {
		return handmod.GetPalmPosition();
	
	}

	public Vector3 GetPalmNormalDirection (HandModel handmod) {
		return handmod.GetPalmNormal();
	}
	*/
}
