using UnityEngine;
using System.Collections;
using Leap;

public class RayController : MonoBehaviour {
	LineRenderer LineRend = null;
	private HandStore handStore;

	// Use this for initialization
	void Start () {
		handStore = HandStore.GetInstance ();
		LineRend = gameObject.GetComponent<LineRenderer> ();

		if (LineRend == null) {
			LineRend = gameObject.AddComponent<LineRenderer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		HandList hands = handStore.GetHands();
		foreach (Hand hand in hands) {
			if (!handStore.IsOpenHand (hand)) {
				// Returning if hand is not opened
				return;
			}
			Vector3 palmNormalDirection = handStore.GetPalmNormalDirection (hand);
			Vector3 position = handStore.GetPalmPositionInWorld (hand);
			RaycastHit rayHit;
			if (Physics.Raycast (position, palmNormalDirection, out rayHit, 100.0f)) {
				Debug.Log ("hit");
				LineRend.SetPositions(new [] {position, rayHit.point} );
				LineRend.SetColors (Color.yellow, Color.yellow);
			}


		
		}



	}
}
