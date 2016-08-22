using UnityEngine;
using System.Collections;

public class GameManager : Photon.PunBehaviour {

	void Start () {
		NetworkManager.InitConfig ();

		// TODO: This will be remove as we don't want to automatically join lobby
		NetworkManager.JoinLobby ();
	}

	override public void OnFailedToConnectToPhoton (DisconnectCause cause) {
		Debug.LogError ("FYP/OnFailedToConnectToPhoton " + cause);
		Debug.LogError ("Please check network connection and app id");
	}

	override public void OnConnectionFail (DisconnectCause cause) {
		Debug.LogError ("FYP/OnConnectionFail " + cause);
		Debug.LogError ("Please check network region and CCU limit");
	}
}
