using UnityEngine;
using System.Collections;

public class ObjectStore {

	private const string LEAP_MOTION_CONTROLLER_TAG = "LeapMotionController";
	private const string ENEMY_TAG = "Enemy";
	private const string ENEMY_MANAGER_NAME = "EnemyManager";
	private const string TRINUS_NAME = "Trinus";

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
}
