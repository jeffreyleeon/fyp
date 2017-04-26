using UnityEngine;
using System.Collections;

public class MsgStore {
	private const string welcomeMsg = "Hello World!";
	private const string extendHandTutorMsg = "Extend your hands if you can't see your hand in the scene";
	private const string flipHandTutorMsg = "Flip your hand if it is flipped in game";
	private const string showHandTutorMsg = "Place both of your hands in front of the camera";
	private const string dismissHandTutorMsg = "Put down your hands and you will not see them in the screen";
	private const string shootingTutorMsg = "Open your palm to shoot bullets";
	private const string changeWeaponTutorMsg = "Close your palm and shake your hand to change bullet type";
	private const string shootingEnemiesTutorMsg = "Aim and kill all the enemies!";
	private const string tutorialEndMsgPartOne = "End of the tutorial, ready to start the first stage in ";
	private const string tutorialEndMsgPartTwo = " seconds!";

	public static string GetExtendHandMsg(){
		return extendHandTutorMsg;
	}

	public static string GetFlipHandMsg(){
		return flipHandTutorMsg;
	}

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

	public static string GetTutorialEndMsgPartOne () {
		return tutorialEndMsgPartOne;
	}

	public static string GetTutorialEndMsgPartTwo () {
		return tutorialEndMsgPartTwo;
	}
}
