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

	public static void JoinLobby () {
		PhotonNetwork.ConnectUsingSettings (gameVersion);
	}

}
