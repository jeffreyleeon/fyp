using UnityEngine;
using System.Collections;
using Leap;

public class RayController : MonoBehaviour {
	private LineRenderer lineRender = null;
	private HandStore handStore;

	void Start () {
		handStore = HandStore.GetInstance ();
		lineRender = gameObject.GetComponent<LineRenderer> ();
		if (lineRender == null) {
			lineRender = gameObject.AddComponent<LineRenderer> ();
			lineRender.SetColors (Color.yellow, Color.yellow);
			lineRender.SetPositions (new [] { Vector3.zero, Vector3.zero });
		}
	}
	
	void FixedUpdate () {
		HandModel[] handModels = new HandModel[handStore.handNum];
		handStore.GetHands ().CopyTo (handModels, 0);
		foreach (HandModel handModel in handModels) {
			if (!handStore.IsOpenHand (handModel)) {
				lineRender.SetPositions (new [] { Vector3.zero, Vector3.zero });
				return;
			}

			Vector3 palmNormal = handModel.GetPalmNormal();
			Vector3 position = handModel.GetPalmPosition();
			RaycastHit rayHit;
			if (Physics.Raycast (position, palmNormal, out rayHit, 100.0f)) {
				lineRender.SetPositions (new [] { position, rayHit.point });
			} else {
				lineRender.SetPositions (new [] { position, (palmNormal * 100.0f)  });
			}
		}
	}
}
