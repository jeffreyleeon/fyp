using UnityEngine;
using System.Collections;

public sealed class HandStore{

	private static HandStore instance = new HandStore();
	private HandModel[] allhands;
	private int handnum;

	private HandStore(){
		allhands = null;
		handnum = 0;
	}

	public static HandStore getInstance(){
		return instance;
	}

	// set hands
	public void setHands(HandModel[] hands){
		if (hands.Length != 0 || handnum != 0) {
			allhands = new HandModel[hands.Length];
			hands.CopyTo (allhands, 0);
			handnum = hands.Length;
			Debug.Log (handnum);
		}
	}



	// check if hand is open
	public bool IsOpenHand(int hand){


		return true;
	}

	// check if hand appear
	public bool IsHandAppear(){
		if (handnum == 0) {
			return false;
		} else {
			return true;
		}
	}
}
