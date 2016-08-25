using UnityEngine;
using System.Collections;

public sealed class NetworkManager {

	static bool multiplayerMode = true;
	static string roomName = "YOLO";
	static int PUNsendRate = 50;
	static int PUNsendRateOnSerialize = 30;
	static string gameversion = "1.0";

	public static void InitConfig () {
		PhotonNetwork.logLevel = PhotonLogLevel.Informational;
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
		PhotonNetwork.autoCleanUpPlayerObjects = true;
		PhotonNetwork.sendRate = PUNsendRate;
		PhotonNetwork.sendRateOnSerialize = PUNsendRateOnSerialize;
	}

	void Start () {
		if (!multiplayerMode) {
			//play single
			return;
		} else {
			ConnectToServer ();
		}

	}

	#region public method

	public void ConnectToServer(){
		if (PhotonNetwork.connected) {
			JoinRoom ();
			return;
		}

		PhotonNetwork.ConnectUsingSettings (gameversion);
	}

	public void JoinRoom(){
		if (roomName == "") {
			PhotonNetwork.JoinRandomRoom ();
		} else {
			PhotonNetwork.JoinRoom (roomName);
		}
	}

	public void CreateRoom(){
		if (roomName == "") {
			roomName = "FYP" + Random.Range(0, 100).ToString ();
		} 
		RoomOptions roomOptions = new RoomOptions ();

		//Room Settings
		{
			roomOptions.MaxPlayers = 4;
		}

		PhotonNetwork.CreateRoom (roomName, roomOptions, null);
	}

	public void StartGame(){
		GameObject gameManager = GameObject.Find ("GameManager");
		gameManager.GetComponent<GameManager> ().enabled = true;
	}
	#endregion

//	#region PUN callbacks
//
//	public override void OnConnectedToMaster ()
//	{
//		JoinRoom ();
//	}
//
//	public override void OnPhotonJoinRoomFailed (object[] codeAndMsg)
//	{
//		// NOT dealng with full room yet
//		CreateRoom ();
//	}
//
//	public override void OnPhotonRandomJoinFailed (object[] codeAndMsg)
//	{
//		CreateRoom ();
//	}
//
//
//	public override void OnJoinedRoom ()
//	{
//		StartGame ();
//	}
//	#endregion
}
