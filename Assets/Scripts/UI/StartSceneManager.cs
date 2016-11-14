using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour {

	public static int startCount = 0;
	public static int sceneIndex = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startCount == 60) {
			ChangeScene.changeToScene (sceneIndex);
		}
	}

	public static void addCount() {
		startCount++;
		print ("count added" + startCount);
	}
}
