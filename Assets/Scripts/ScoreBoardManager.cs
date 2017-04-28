using UnityEngine;
using System.Collections;

public class ScoreBoardManager : MonoBehaviour {

	void Start () {
		RenderSettings.skybox = ObjectStore.ActiveSkybox;
	}

	// Update is called once per frame
	void Update () {
		// Debug usage
		ListenKeyboard ();
	}

	void ListenKeyboard () {
		if (Input.GetKey (KeyCode.Space)) {
			// Enter bright scene directly
			ChangeScene.ChangeToScene (ChangeScene.MENU_SCENE);
		}
	}

	void OnDestroy () {
		GameObject decoration = ObjectStore.FindDecoration ();
		Destroy (decoration);
	}

}
