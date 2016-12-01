﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour {

	public static int startCount = 0;
	public static int sceneIndex = 1;
	public static GameObject loadingPanel;

	// Use this for initialization
	void Start () {
		loadingPanel = GameObject.Find ("LoadingPanel");
		loadingPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (startCount == 60) {
			ChangeScene.changeToScene (sceneIndex);
		}
	}

	public static void enableLoading() {
		loadingPanel.SetActive(true);
	}

	public static void disableLoading() {
		loadingPanel.SetActive(false);

		//reset current amount
		startCount = 0;
		LoadingBar.currentAmount = 0;
	}

	public static void addCount() {
		startCount++;
		LoadingBar.currentAmount++;
		print ("count added" + startCount);
	}
}
