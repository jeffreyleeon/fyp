using UnityEngine;
using System.Collections;

public class ScoreBoardManager : MonoBehaviour {

	void Start () {
		RenderSettings.skybox = ObjectStore.ActiveSkybox;
	}

	void OnDestroy () {
		GameObject decoration = ObjectStore.FindDecoration ();
		Destroy (decoration);
	}

}
