using UnityEngine;
using System.Collections;
using Leap;

public sealed class HandStore{

	private static HandStore instance = new HandStore();
	private HandList allHands;
	private int handNum;
	private const int extendFingerThreshold = 4;

	private HandStore(){
		allHands = null;
		handNum = 0;
	}

	public static HandStore GetInstance(){
		return instance;
	}

	// set hands
	public void SetHands(Frame leapFrame){
		handNum = leapFrame.Hands.Count;
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
		if (handNum == 0) {
			return false;
		} else {
			return true;
		}
	}
}
