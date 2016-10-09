using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectStore {

	private const string LEAP_MOTION_CONTROLLER_TAG = "LeapMotionController";
	private const string ENEMY_TAG = "Enemy";
	private const string ENEMY_MANAGER_NAME = "EnemyManager";
	private const string TRINUS_NAME = "Trinus";
	private const string BULLET_TAG = "Bullet";

	private static readonly Dictionary<string, int> ScoreDictionary = new Dictionary<string, int>{
		{ENEMY_TAG, 10}
	};

	public static GameObject FindLeapMotionController () {
		return GameObject.FindGameObjectWithTag (LEAP_MOTION_CONTROLLER_TAG);
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

	public static string GetEnemyTag (){
		return ENEMY_TAG;
	}

	public static string GetBulletTag(){
		return BULLET_TAG;
	}

	public static int GetScoreByTag(string tag){
		int score;
		if (ScoreDictionary.TryGetValue (tag, out score)) {
			return score;
		}
		Debug.Log ("/FYP/ObjectStore/GetScoreByTag: Given tag " + tag + " not found.");
		return 0;
	}
}
