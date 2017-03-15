using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectStore {

	private const string LEAP_MOTION_CONTROLLER_TAG = "LeapMotionController";
	private const string ENEMY_TAG = "Enemy";
	private const string SHOOTING_MANAGER_NAME = "ShootingManager";
	private const string ENEMY_MANAGER_NAME = "EnemyManager";
	private const string TRINUS_NAME = "Trinus";
	private const string BULLET_TAG = "Bullet";
	private const string PLAYER_TAG = "Player";
	private const string MENU_BUTTON_NAME = "MenuButton";
	private const string START_BUTTON_NAME = "StartButton";
	private const string MAP_BUTTON_NAME = "MapButton";
	private const string FOREST_BUTTON_NAME = "forestButton";
	private const string SPACE_BUTTON_NAME = "spaceButton";
	private const string HORROR_BUTTON_NAME = "horrorButton";
	private const string CHRISTMAS_BUTTON_NAME = "christmasButton";
	private const string SCENE_MANAGER_NAME = "SceneManager";
	private const string GAME_MANAGER_NAME = "GameManager";
	private const string DEATH_PANEL_NAME = "Death";
	private const string BULLET_TYPE_IMAGE = "BulletTypeImage";
	private const string UI_WEAPON_TAG = "UI_Weapon";
	private const string UI_SCORE_TAG = "UI_Score";
	private const string UI_HP_TAG = "UI_HP";

	private static readonly Dictionary<string, int> ScoreDictionary = new Dictionary<string, int>{
		{ENEMY_TAG, 10}
	};

	public static GameObject FindLeapMotionController () {
		return GameObject.FindGameObjectWithTag (LEAP_MOTION_CONTROLLER_TAG);
	}
		
	public static GameObject[] FindEnemies () {
		return GameObject.FindGameObjectsWithTag (ENEMY_TAG);
	}

	public static GameObject[] FindBullets () {
		return GameObject.FindGameObjectsWithTag (BULLET_TAG);
	}

	public static GameObject FindShootingManager () {
		return GameObject.Find (SHOOTING_MANAGER_NAME);
	}

	public static GameObject FindGameManager(){
		return GameObject.Find (GAME_MANAGER_NAME);
	}

	public static GameObject FindEnemyManager () {
		return GameObject.Find (ENEMY_MANAGER_NAME);
	}

	public static GameObject FindTrinus () {
		return GameObject.Find (TRINUS_NAME);
	}

	public static GameObject FindSceneManager () {
		return GameObject.Find (SCENE_MANAGER_NAME);
	}

	public static GameObject FindDeathPanel () {
		return GameObject.Find(DEATH_PANEL_NAME);
	}

	public static GameObject[] FindBulletTypeImages () {
		return GameObject.FindGameObjectsWithTag (BULLET_TYPE_IMAGE);
	}

	public static GameObject[] FindAllPlayers () {
		return GameObject.FindGameObjectsWithTag (PLAYER_TAG);
	}	

	public static GameObject[] FindUIHP(){
		return GameObject.FindGameObjectsWithTag (UI_HP_TAG);
	}

	public static GameObject[] FindUIScore(){
		return GameObject.FindGameObjectsWithTag (UI_SCORE_TAG);
	}

	public static GameObject[] FindUIWeapon(){
		return GameObject.FindGameObjectsWithTag (UI_WEAPON_TAG);
	}

	public static string GetEnemyTag (){
		return ENEMY_TAG;
	}

	public static string GetBulletTag(){
		return BULLET_TAG;
	}

	public static string GetMenuButtonName() {
		return MENU_BUTTON_NAME;
	}

	public static string GetStartButtonName() {
		return START_BUTTON_NAME;
	}

	public static string GetMapButtonName() {
		return MAP_BUTTON_NAME;
	}

	public static string GetForestButtonName() {
		return FOREST_BUTTON_NAME;
	}

	public static string GetSpaceButtonName() {
		return SPACE_BUTTON_NAME;
	}

	public static string GetHorrorButtonName() {
		return HORROR_BUTTON_NAME;
	}

	public static string GetChristmasButtonName() {
		return CHRISTMAS_BUTTON_NAME;
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
