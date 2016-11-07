using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public static void changeToScene (int changeTheScene) {
		SceneManager.LoadScene (changeTheScene);
	}
}
