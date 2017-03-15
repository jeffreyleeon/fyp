using UnityEngine;
using System.Collections;

public class ScoreBoardManager : MonoBehaviour {

	void OnDestroy () {
		GameObject decoration = ObjectStore.FindDecoration ();
		Destroy (decoration);
	}

}
