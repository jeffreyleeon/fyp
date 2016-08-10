using UnityEngine;
using System.Collections;
using Leap;

public sealed class HandStore{

	private static HandStore instance = new HandStore();
	private HandList allHands;
	private const int extendFingerThreshold = 4;

	private int handNum {
		get {
			return allHands.Count;
		}
	}

	private HandStore(){
		allHands = new HandList();
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
}
