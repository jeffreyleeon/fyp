using UnityEngine;
using System.Collections;

public class MsgStore {
	private const string welcomeMsg = "Hello World!";

	public static string GetWelcomeMsg(){
		return welcomeMsg;
	}
}
