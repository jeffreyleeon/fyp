using UnityEngine;
using System.Collections;

public class GameManager : Photon.PunBehaviour {
	GameObject trinus;
	GameObject player;
	GameObject enemyManager;

	[Tooltip("Room Name, empty for joining random room. If failed, create one with random name. Specifiying roomName will try to connect to that room, if NOT EXIST, create room with that name")]
	public string roomName = "";

	void Awake(){
		trinus = ObjectStore.FindTrinus ();
		enemyManager = ObjectStore.FindEnemyManager ();

		NetworkManager.InitConfig ();
		if (!NetworkManager.IsServerConnected) {
			NetworkManager.ConnectServer ();
		} else {
			JoinGameRoom ();
		}
	}

	void JoinGameRoom () {
		if (roomName == "") {
			NetworkManager.JoinRandomRoom ();
		} else {
			NetworkManager.JoinOrCreateRoom (roomName, 2);
		}
	}

	void StartGame () {
		player = PhotonNetwork.Instantiate ("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
		trinus.transform.parent = player.transform;
		enemyManager.GetComponent<Spawn> ().enabled = true;
	}

	#region PUN callbacks

	override public void OnConnectedToMaster () {
		JoinGameRoom ();
	}

	override public void OnFailedToConnectToPhoton (DisconnectCause cause) {
		Debug.LogError ("FYP/OnFailedToConnectToPhoton " + cause);
		Debug.LogError ("Please check network connection and app id");
	}

	override public void OnConnectionFail (DisconnectCause cause) {
		Debug.LogError ("FYP/OnConnectionFail " + cause);
		Debug.LogError ("Please check network region and CCU limit");
	}

	override public void OnPhotonRandomJoinFailed (object[] codeAndMsg) {
		Debug.LogError ("FYP/OnPhotonRandomJoinFailed " + codeAndMsg[0] + " " + codeAndMsg[1]);
		NetworkManager.CreateRoom ();
	}

	override public void OnPhotonJoinRoomFailed (object[] codeAndMsg) {
		Debug.LogError ("FYP/OnPhotonJoinRoomFailed " + codeAndMsg[1]);
	}

	override public void OnPhotonCreateRoomFailed (object[] codeAndMsg) {
		Debug.LogError ("FYP/OnPhotonCreateRoomFailed " + codeAndMsg[1]);
	}

	override public void OnCreatedRoom () {
		Debug.Log ("FYP/OnCreatedRoom");
	}

	override public void OnJoinedRoom () {
		Debug.Log ("FYP/OnJoinedRoom");

		// Start game!
		StartGame ();
	}

	#endregion
}
