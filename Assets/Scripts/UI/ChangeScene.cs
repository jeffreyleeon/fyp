using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public const int MENU_SCENE = 8;
	public const int BRIGHT_SCENE = 1;
	public const int TUTORIAL_SCENE = 2;
	public const int SCORE_SCENE = 3;
	public const int MAP_SCENE = 4;
	public const int SPACE_SCENE = 5;
	public const int CHRISTMAS_SCENE = 6;
	public const int HORROR_SCENE = 7;
	public const int TRAILOR_SCENE = 0;

	public static void ChangeToScene (int sceneIndex) {
		if (sceneIndex == SCORE_SCENE) {
			RetainDecoration ();
		}
		SceneManager.LoadScene (sceneIndex);
	}

	private static void RetainDecoration () {
		GameObject decoration = ObjectStore.FindDecoration ();
		DontDestroyOnLoad (decoration);
	}
}

