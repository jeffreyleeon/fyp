using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectStore {

	private const string LEAP_MOTION_CONTROLLER_TAG = "LeapMotionController";
	private const string ENEMY_TAG = "Enemy";
	private const string ENEMY_MANAGER_NAME = "EnemyManager";
	private const string TRINUS_NAME = "Trinus";
	private const string BULLET_TAG = "Bullet";
	private const string PLAYER_TAG = "Player";
	private const string START_BUTTON_NAME = "StartButton";

	private static readonly Dictionary<string, int> ScoreDictionary = new Dictionary<string, int>{
		{ENEMY_TAG, 10}
	};

	public static GameObject FindLeapMotionController () {
		return GameObject.FindGameObjectWithTag (LEAP_MOTION_CONTROLLER_TAG);
	}

	public static GameObject FindShootingController (){
		return GameObject.Find ("ShootingManager");
	}

	public static GameObject[] FindEnemies () {
		return GameObject.FindGameObjectsWithTag (ENEMY_TAG);
	}

	public static GameObject FindEnemyManager () {
		return GameObject.Find (ENEMY_MANAGER_NAME);
	}

	public static GameObject FindTrinus () {
		return GameObject.Find (TRINUS_NAME);
	}

	public static GameObject[] FindAllPlayers () {
		return GameObject.FindGameObjectsWithTag (PLAYER_TAG);
	}	

	public static string GetEnemyTag (){
		return ENEMY_TAG;
	}

	public static string GetBulletTag(){
		return BULLET_TAG;
	}

	public static string GetStartButtonName() {
		return START_BUTTON_NAME;
	}

	public static int GetScoreByTag(string tag){
		int score;
		if (ScoreDictionary.TryGetValue (tag, out score)) {
			return score;
		}
		Debug.Log ("/FYP/ObjectStore/GetScoreByTag: Given tag " + tag + " not found.");
		return 0;
	}

	public static Player FindMyPlayer(){
		GameObject[] players = ObjectStore.FindAllPlayers ();
		foreach (GameObject tempGO in players) {
			Player tempPlayer = tempGO.GetComponent<Player> ();
			if (tempPlayer.photonView.isMine) {
				return tempPlayer;
			}
		}
		return null;
	}
}
