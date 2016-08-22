using UnityEngine;
using System.Collections;

public sealed class NetworkManager {

	private static string gameVersion = "1.0";

	public static void InitConfig () {
		PhotonNetwork.sendRate = 50;
		PhotonNetwork.sendRateOnSerialize = 30;

		PhotonNetwork.logLevel = PhotonLogLevel.Full;
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
	}

	public static void ConnectToMasterServer () {
		PhotonNetwork.ConnectUsingSettings (gameVersion);
	}

	public static void CreateRoom (byte playerPerRoom = 2, string roomName = null) {
		PhotonNetwork.CreateRoom (
			roomName,
			new RoomOptions() {
				maxPlayers = playerPerRoom
			},
			null
			);
	}

	/// <summary>
	/// Joins the room.
	/// If roomName is not given, will try to join random room and create room if no random room to join
	/// If roomName is given but the room is not able to join, will throw appropriate error
	/// If roomName is given but the room does not exist, will create one for user
	/// </summary>
	/// <param name="roomName">Room name.</param>
	public static void JoinRoom (string roomName = null) {
		if (roomName == null) {
			PhotonNetwork.JoinRandomRoom ();
		} else {
			PhotonNetwork.JoinOrCreateRoom (roomName, null, null);
		}
	}

	public static void CreatePlayer () {
		PhotonNetwork.Instantiate (
			"Player",
			Vector3.zero,
			Quaternion.identity,
			0
		);
	}

}
