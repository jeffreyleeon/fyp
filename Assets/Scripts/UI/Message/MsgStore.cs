using UnityEngine;
using System.Collections;

public class MsgStore {
	private const string welcomeMsg = "Hello World!";
	private const string showHandTutorMsg = "Place your hands in front of the camera to see your hands";
	private const string dismissHandTutorMsg = "Put down your hands and you will not see them in the screen";
	private const string shootingTutorMsg = "Open your palm to shoot bullets";
	private const string shootingEnemiesTutorMsg = "Aim and shoot 5 enemies";

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

	public static string GetShootingEnemiesTutorMsg () {
		return shootingEnemiesTutorMsg;
	}
}
