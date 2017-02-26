using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour {

	public static int startCount = 0;
	public static int MENU_SCENE = ChangeScene.MENU_SCENE;
	public static int BRIGHT_SCENE = ChangeScene.BRIGHT_SCENE;
	public static int TUTORIAL_SCENE = ChangeScene.TUTORIAL_SCENE;
	public static int SCORE_SCENE = ChangeScene.SCORE_SCENE;
	public static int MAP_SCENE = ChangeScene.MAP_SCENE;
	public static int sceneIndex = -1;
	public static GameObject loadingPanel;

	// Use this for initialization
	void Start () {
		loadingPanel = GameObject.Find ("LoadingPanel");
		loadingPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (startCount >= 60) {
			ChangeScene.ChangeToScene (sceneIndex);
		}

		// Debug usage
		ListenKeyboard ();
	}

	void ListenKeyboard () {
		if (Input.GetKey (KeyCode.S)) {
			// Enter bright scene directly
			ChangeScene.ChangeToScene (BRIGHT_SCENE);
		} else if (Input.GetKey (KeyCode.T)) {
			// Enter tutorial scene directly
			ChangeScene.ChangeToScene (TUTORIAL_SCENE);
		} else if (Input.GetKey (KeyCode.M)) {
			ChangeScene.ChangeToScene (MAP_SCENE);
		}
	}

	public static void SetTargetScene (int targetSceneIndex) {
		sceneIndex = targetSceneIndex;
	}

	public static void EnableLoading() {
		if (loadingPanel == null) {
			return;
			print ("loading Panel not found");
		}
		loadingPanel.SetActive(true);
	}

	public static void DisableLoading() {
		if (loadingPanel == null) {
			return;
		}
		loadingPanel.SetActive(false);

		//reset current amount
		startCount = 0;
		LoadingBar.currentAmount = 0;
	}

	public static void AddCount() {
		startCount++;
		LoadingBar.currentAmount++;
		print ("count added" + startCount);
	}
}
