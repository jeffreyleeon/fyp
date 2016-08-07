using UnityEngine;
using System.Collections;

public sealed class HandStore{

	private static HandStore instance = new HandStore();
	private HandModel[] allHands;
	private int handNum;

	private HandStore(){
		allHands = null;
		handNum = 0;
	}

	public static HandStore GetInstance(){
		return instance;
	}

	// set hands
	public void SetHands(HandModel[] hands){
			allHands = new HandModel[hands.Length];
			hands.CopyTo (allHands, 0);
			handNum = hands.Length;
	}

	public HandModel[] GetHands (){
		return allHands;
	}

	// check if hand is open
	public bool IsOpenHand(int hand){


		return true;
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
