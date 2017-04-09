﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour {

	public int threshold = 60;
	public static int startCount = 0;
	public static int MENU_SCENE = ChangeScene.MENU_SCENE;
	public static int BRIGHT_SCENE = ChangeScene.BRIGHT_SCENE;
	public static int TUTORIAL_SCENE = ChangeScene.TUTORIAL_SCENE;
	public static int SCORE_SCENE = ChangeScene.SCORE_SCENE;
	public static int MAP_SCENE = ChangeScene.MAP_SCENE;
	public static int SPACE_SCENE = ChangeScene.SPACE_SCENE;
	public static int CHRISTMAS_SCENE = ChangeScene.CHRISTMAS_SCENE;
	public static int HORROR_SCENE = ChangeScene.HORROR_SCENE;
	public static int sceneIndex = -1;
	public static GameObject loadingPanel;

	public static int[] LEVEL = { BRIGHT_SCENE, CHRISTMAS_SCENE, SPACE_SCENE, HORROR_SCENE };

	// Use this for initialization
	void Start () {
		loadingPanel = GameObject.Find ("LoadingPanel");
		loadingPanel.SetActive(false);

		LoadingBar.SetMax (threshold);
	}
	
	// Update is called once per frame
	void Update () {
		if (startCount >= threshold) {
			ChangeScene.ChangeToScene (sceneIndex);
			startCount = 0;
			sceneIndex = -1;
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

	public static void SetTutorNext (int targetNext) {
		TutorManager.SetNextScene(targetNext);
	}

	public static int GetNextLevel (int currentLevel){
		for (int i = 0; i < LEVEL.Length; i++) {
			if (LEVEL [i] == currentLevel) {
				if (i + 1 == LEVEL.Length) {
					//last level
					return BRIGHT_SCENE;
				} else {
					return LEVEL [i + 1];
				}
			}
		}
		Debug.LogError ("StartSceneManager/GetNextLevel: wrong currentLevel");
		return -1;
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
