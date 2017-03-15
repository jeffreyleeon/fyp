using UnityEngine;
using System.Collections;

public class MsgStore {
	private const string welcomeMsg = "Hello World!";
	private const string showHandTutorMsg = "Place both of your hands in front of the camera";
	private const string dismissHandTutorMsg = "Put down your hands and you will not see them in the screen";
	private const string shootingTutorMsg = "Open your palm to shoot bullets";
	private const string changeWeaponTutorMsg = "Close your plam and shake your hand to change bullet type";
	private const string shootingEnemiesTutorMsg = "Aim and kill all the enemies!";
	private const string tutorialEndMsg = "End of the tutorial, ready to start the first stage in 10 seconds!";

	public static string GetWelcomeMsg(){
		return welcomeMsg;
	}

	public static string GetShowHandTutorMsg () {
		return showHandTutorMsg;
	}

	public static string GetDismissHandTutorMsg () {
		return dismissHandTutorMsg;
	}

	public static string GetShootingTutorMsg () {
		return shootingTutorMsg;
	}

	public static string GetChangeWeaponTutorMsg () {
		return changeWeaponTutorMsg;
	}

	public static string GetShootingEnemiesTutorMsg () {
		return shootingEnemiesTutorMsg;
	}

	public static string GetTutorialEndMsg () {
		return tutorialEndMsg;
	}
}
