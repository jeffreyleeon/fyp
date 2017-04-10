using UnityEngine;
using System.Collections;

public class DisableNextButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (CurrentLevel.currentLevel == ChangeScene.HORROR_SCENE) {
			this.gameObject.SetActive(false);
		}
	}

}
