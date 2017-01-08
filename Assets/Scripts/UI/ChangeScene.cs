using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : Photon.MonoBehaviour {

	public static int BRIGHT_SCENE = 1;
	public static int TUTORIAL_SCENE = 2;
	public static int SCORE_SCENE = 3;

	public static void ChangeToScene (int sceneIndex) {
		SceneManager.LoadScene (sceneIndex);
	}

	[PunRPC]
	public static void BroadcastChangeToScene(int sceneIndex) {
		ChangeToScene (sceneIndex);
	}
}

