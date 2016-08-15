using UnityEngine;
using System.Collections;

public class HandListener : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		HandController Controller = GetComponent<HandController> ();
		HandStore.GetInstance().SetHands (Controller.GetAllGraphicsHands());
	}
}
