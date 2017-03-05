using UnityEngine;
using System.Collections;

public class SceneSetting : MonoBehaviour {
	GameObject trinus;
	GameObject leap;


	// Use this for initialization
	void Start () {
		trinus = ObjectStore.FindTrinus ();
		leap = ObjectStore.FindLeapMotionController ();

		switch (CurrentSceneIndex()){
		case ChangeScene.MENU_SCENE:
		case ChangeScene.SCORE_SCENE:
			trinus.transform.position = new Vector3 (0, 0, 0);
			leap.SetActive (false);
			break;	
		case ChangeScene.BRIGHT_SCENE:
			leap.SetActive (true);
			break;
			
		}
	}
	
	void OnDestroy(){
		//reenable leap, otherwise objectstore cannot find
		leap.SetActive (true);
	}

	private int CurrentSceneIndex(){
		return SceneManagerHelper.ActiveSceneBuildIndex;
	}
}
