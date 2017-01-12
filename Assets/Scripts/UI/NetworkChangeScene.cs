using UnityEngine;
using System.Collections;

public class NetworkChangeScene : Photon.MonoBehaviour {

	[PunRPC]
	public void BroadcastChangeToScene(int sceneIndex) {
		ChangeScene.ChangeToScene (sceneIndex);
	}
}
