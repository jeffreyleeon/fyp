using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public static int BRIGHT_SCENE = 1;
	public static int TUTORIAL_SCENE = 2;
	public static int SCORE_SCENE = 3;
	public static int MAP_SCENE = 4;

	public static void ChangeToScene (int sceneIndex) {
		SceneManager.LoadScene (sceneIndex);
	}
}

