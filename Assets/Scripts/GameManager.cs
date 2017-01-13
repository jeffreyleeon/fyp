using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : Photon.PunBehaviour {
	GameObject trinus;
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

	void Start () {
		PlayBackgroundMusic ();
	}

	void JoinGameRoom () {
		if (roomName == "") {
			NetworkManager.JoinRandomRoom ();
		} else {
			NetworkManager.JoinOrCreateRoom (roomName, 2);
		}
	}

	void StartGame () {
		GameObject player;
		player = PhotonNetwork.Instantiate ("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
		trinus.transform.parent = player.transform;
		enemyManager.GetComponent<Spawn> ().enabled = true;
	}

	#region PlayerDie

	public void PlayerDie(){
		StartCoroutine ("ActivateDeath");
	}

	private bool AllPlayerDie(){
		bool allDie = true;
		GameObject[] allPlayers = ObjectStore.FindAllPlayers ();
		foreach (GameObject plyrGO in allPlayers) {
			Player plyr = plyrGO.GetComponent<Player> ();
			if (plyr.GetCurrentHealth() > 0) {
				allDie = false;
				break;
			}
		}
		return allDie;
	}

	IEnumerator ActivateDeath(){
		//Fading in death panel
		GameObject deathPanel = ObjectStore.FindDeathPanel();
		deathPanel.GetComponent<Image> ().fillCenter = true;
		deathPanel.GetComponent<Image> ().CrossFadeColor (Color.red, 1.0f, false, false);
		yield return new WaitForSeconds (1.0f);
		deathPanel.GetComponent<Image> ().CrossFadeColor (Color.black, 0.5f, false, false);
		yield return new WaitForSeconds (0.5f);
		deathPanel.GetComponent<Image> ().CrossFadeAlpha (150.0f, 1.0f, false);
		yield return new WaitForSeconds (1.0f);


		//extract trinus from player and destroy player object
		GameObject trinus = ObjectStore.FindTrinus();
		trinus.transform.parent = null;
		if (AllPlayerDie()) {
			//not in object store
			GameObject sceneMan = ObjectStore.FindSceneManager();
			sceneMan.GetPhotonView().RPC ("BroadcastChangeToScene", PhotonTargets.AllViaServer, ChangeScene.SCORE_SCENE);
		} else {
			deathPanel.GetComponent<Image> ().CrossFadeAlpha (0f, 1.0f, false);
			trinus.transform.position = new Vector3 (0, 10, -10);
			ObjectStore.FindMyPlayer().Kill();
		}


	}

	#endregion

	#region Background music

	void PlayBackgroundMusic () {
		AudioSource audio = GetComponent<AudioSource>();
		if (audio != null) {
			audio.Play();
		}
	}

	#endregion

	#region PUN callbacks

	override public void OnConnectedToMaster () {
		JoinGameRoom ();
	}

	override public void OnFailedToConnectToPhoton (DisconnectCause cause) {
		PhotonNetwork.offlineMode = true;
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
