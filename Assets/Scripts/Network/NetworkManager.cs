using UnityEngine;
using System.Collections;

public sealed class NetworkManager {

	static int PUNsendRate = 50;
	static int PUNsendRateOnSerialize = 30;
	static string gameversion = "1.0";
	const byte maxNumOfPlayers = 4;

	public static void InitConfig () {
		PhotonNetwork.logLevel = PhotonLogLevel.ErrorsOnly;
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
		PhotonNetwork.autoCleanUpPlayerObjects = true;
		PhotonNetwork.sendRate = PUNsendRate;
		PhotonNetwork.sendRateOnSerialize = PUNsendRateOnSerialize;
	}

	/// <summary>
	/// Connects the server.
	/// Caller should override OnConnectedToMaster, OnFailedToConnectToPhoton and OnConnectionFail callbacks from PUN and deal with it themselves
	/// </summary>
	public static void ConnectServer () {
		if (PhotonNetwork.connected) {
			Debug.Log ("FYP/NetworkManager/ConnectServer Server is connected");
			return;
		}
		PhotonNetwork.ConnectUsingSettings (gameversion);
	}

	/// <summary>
	/// Determines if is server connected.
	/// </summary>
	/// <returns><c>true</c> if is server connected; otherwise, <c>false</c>.</returns>
	public static bool IsServerConnected {
		get {
			return PhotonNetwork.connected;
		}
	}

	/// <summary>
	/// Joins the room.
	/// Caller should override OnJoinedRoom, OnPhotonJoinRoomFailed callbacks from PUN and deal with it themselves
	/// </summary>
	/// <param name="roomName">Room name, must be provided</param>
	public static void JoinRoom (string roomName) {
		if (roomName == "") {
			Debug.LogError ("FYP/NetworkManager/JoinRoom roomName must be provided");
			return;
		}
		PhotonNetwork.JoinRoom (roomName);
	}

	/// <summary>
	/// Joins a random room.
	/// Caller should override OnConnectedToMaster, OnFailedToConnectToPhoton and OnConnectionFail callbacks from PUN and deal with it themselves
	/// </summary>
	public static void JoinRandomRoom () {
		PhotonNetwork.JoinRandomRoom ();
	}

	/// <summary>
	/// Joins or create room.
	/// </summary>
	/// <param name="roomName">Room name, must be provided</param>
	/// <param name="numOfPlayers">Number of players in created room, if needed</param>
	public static void JoinOrCreateRoom (string roomName, byte numOfPlayers = maxNumOfPlayers) {
		if (roomName == "") {
			Debug.LogError ("FYP/NetworkManager/JoinOrCreateRoom roomName must be provided");
			return;
		}
		RoomOptions roomOptions = new RoomOptions ();
		//Room Settings
		{
			roomOptions.MaxPlayers = numOfPlayers;
		}
		PhotonNetwork.JoinOrCreateRoom (roomName, roomOptions, null);
	}

	/// <summary>
	/// Creates the room.
	/// Caller should override OnCreatedRoom, OnJoinedRoom and OnPhotonCreateRoomFailed callbacks from PUN and deal with it themselves
	/// </summary>
	/// <param name="roomName">Room name. Passing null will create room with random name</param>
	/// <param name="numOfPlayers">Number of players.</param>
	public static void CreateRoom(string roomName = "", byte numOfPlayers = maxNumOfPlayers){
		RoomOptions roomOptions = new RoomOptions ();
		//Room Settings
		{
			roomOptions.MaxPlayers = numOfPlayers;
		}
		PhotonNetwork.CreateRoom (roomName, roomOptions, null);
	}
}
