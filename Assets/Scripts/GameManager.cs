using UnityEngine;
using System.Collections;

public class GameManager : Photon.PunBehaviour {

	private const string roomName = "FYP_DEMO";

	void Start () {
		NetworkManager.InitConfig ();

		NetworkManager.ConnectToMasterServer ();
	}

	override public void OnFailedToConnectToPhoton (DisconnectCause cause) {
		Debug.LogError ("FYP/OnFailedToConnectToPhoton " + cause);
		Debug.LogError ("Please check network connection and app id");
	}

	override public void OnConnectionFail (DisconnectCause cause) {
		Debug.LogError ("FYP/OnConnectionFail " + cause);
		Debug.LogError ("Please check network region and CCU limit");
	}

	override public void OnConnectedToMaster () {
		// TODO: Current force join room of demo game
		Debug.Log ("FYP/OnConnectedToMaster");
		NetworkManager.JoinRoom ();
	}

	override public void OnCreatedRoom () {
		Debug.Log ("FYP/OnCreatedRoom");
	}

	override public void OnJoinedRoom () {
		Debug.Log ("FYP/OnJoinedRoom");
	}

	override public void OnPhotonRandomJoinFailed (object[] codeAndMsg) {
		Debug.Log ("FYP/OnPhotonRandomJoinFailed " + codeAndMsg[0] + " " + codeAndMsg[1]);
		NetworkManager.CreateRoom ();
	}
}
