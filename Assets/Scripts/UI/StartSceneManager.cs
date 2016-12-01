﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour {

	public static int startCount = 0;
	public static int BRIGHT_SCENE = 1;
	public static int sceneIndex = -1;
	public static GameObject loadingPanel;

	// Use this for initialization
	void Start () {
		loadingPanel = GameObject.Find ("LoadingPanel");
		loadingPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (startCount == 60) {
			ChangeScene.ChangeToScene (sceneIndex);
		}

		// Debug usage
		ListenKeyboard ();
	}

	void ListenKeyboard () {
		if (Input.GetKey (KeyCode.S)) {
			// Enter bright scene directly
			ChangeScene.ChangeToScene (sceneIndex);
		}
	}

	public static void SetTargetScene (int targetSceneIndex) {
		sceneIndex = targetSceneIndex;
	}

	public static void EnableLoading() {
		if (loadingPanel == null) {
			return;
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