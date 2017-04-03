using UnityEngine;
using System.Collections;

public class SceneSetting : MonoBehaviour {
	GameObject trinus;
	GameObject leap;
	HandStore handStore;

	// Use this for initialization
	void Start () {
		trinus = ObjectStore.FindTrinus ();
		leap = ObjectStore.FindLeapMotionController ();
		handStore = HandStore.GetInstance ();

		switch (CurrentSceneIndex()){
		case ChangeScene.MENU_SCENE:
		case ChangeScene.SCORE_SCENE:
			NetworkManager.DisconnectServer ();
			trinus.transform.position = new Vector3 (0, 0, 0);
			leap.SetActive (false);
			break;	
		default:
			handStore.resetHands ();
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
