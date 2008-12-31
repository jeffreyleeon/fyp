using UnityEngine;
using System.Collections;

public class ObjectStore {

	private const string LEAP_MOTION_CONTROLLER_TAG = "LeapMotionController";
	private const string ENEMY_TAG = "Enemy";

	public static GameObject FindLeapMotionController () {
		return GameObject.FindGameObjectWithTag (LEAP_MOTION_CONTROLLER_TAG);
	}

	public static GameObject[] FindEnemies () {
		return GameObject.FindGameObjectsWithTag (ENEMY_TAG);
	}
}
