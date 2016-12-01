using UnityEngine;
using System.Collections;

public class MsgStore {
	private const string welcomeMsg = "Hello World!";
	private const string showHandTutorMsg = "Place your hands in front of the camera to see your hands";

	public static string GetWelcomeMsg(){
		return welcomeMsg;
	}

	public static string GetShowHandTutorMsg () {
		return showHandTutorMsg;
	}
}
