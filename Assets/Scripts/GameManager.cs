using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : Photon.PunBehaviour {
	GameObject trinus;
	GameObject enemyManager;
	StatisticsStore statisticsStore;

	[Tooltip("Room Name, empty for joining random room. If failed, create one with random name. Specifiying roomName will try to connect to that room, if NOT EXIST, create room with that name")]
	public string roomName = "";

	private bool playerWin = false;

	void Awake(){
		if (PhotonNetwork.connected) {
			//disconnect if return from score scene
			PhotonNetwork.Disconnect ();
		}
		trinus = ObjectStore.FindTrinus ();
		enemyManager = ObjectStore.FindEnemyManager ();
		if (GameSettings.online) {
			NetworkManager.InitConfig ();
			if (!NetworkManager.IsServerConnected) {
				NetworkManager.ConnectServer ();
			} else {
				JoinGameRoom ();
			}
		} else {
			PhotonNetwork.offlineMode = !GameSettings.online;
			NetworkManager.CreateRoom("localroom");
		}
	}

	void Start () {
		PlayBackgroundMusic ();
		RecordSkybox ();
		ResetStat ();
		CurrentLevel.currentLevel = SceneManagerHelper.ActiveSceneBuildIndex;
	}

	void RecordSkybox () {
		ObjectStore.ActiveSkybox = RenderSettings.skybox;
	}

	void ResetStat () {
		statisticsStore = StatisticsStore.GetInstance ();
		statisticsStore.ResetStat ();
		statisticsStore.SetGameStartTime (System.DateTime.Now);
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
		player = PhotonNetwork.Instantiate ("Player", new Vector3( (3.0f * PhotonNetwork.playerList.Length-1), -6.0f, 0), Quaternion.identity, 0);
		trinus.transform.parent = player.transform;
		ChangeLayers (player, LayerMask.NameToLayer ("LocalPlayerModel"));
		enemyManager.GetComponent<Spawn> ().enabled = true;
	}

	void ChangeLayers (GameObject go, int layer) {
		go.layer = layer;
		foreach (Transform child in go.transform) {
			ChangeLayers (child.gameObject, layer);
		}
	}

	#region PlayerWin

	public void PlayerWin() {
		playerWin = true;

		Player player = ObjectStore.FindMyPlayer ();
		StatisticsStore.GetInstance ().SetPlayerEndGameHP ((float)player.GetCurrentHealth ());

		StartCoroutine ("ActivateWin");
	}

	IEnumerator ActivateWin() {
		yield return new WaitForSeconds (5);
		//extract trinus from player and destroy player object
		GameObject trinus = ObjectStore.FindTrinus();
		trinus.transform.parent = null;

		ChangeScene.ChangeToScene (ChangeScene.SCORE_SCENE);

//		GameObject sceneMan = ObjectStore.FindSceneManager();
//		sceneMan.GetPhotonView().RPC ("BroadcastChangeToScene", PhotonTargets.AllViaServer, ChangeScene.SCORE_SCENE);
	}

	#endregion

	#region PlayerDie

	public void PlayerDie(){
		if (playerWin) {
			return;
		}
		StatisticsStore.GetInstance ().SetPlayerEndGameHP (0.0f);
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
			DisableUI ();
		}
	}

	private void DisableUI(){
		GameObject[] UI_HP = ObjectStore.FindUIHP ();
		foreach (GameObject i in UI_HP) {
			i.gameObject.SetActive (false);
		}
		GameObject[] UI_Weapon = ObjectStore.FindUIWeapon ();
		foreach (GameObject i in UI_Weapon) {
			i.gameObject.SetActive (false);
		}
	}

	#endregion

	#region Update Canvas

	public void UpdateBossStatus(int max) {
		GameObject [] BossStatus = ObjectStore.FindBossStatus ();

		for (int i = 0; i < BossStatus.Length; ++i) {
			BossStatusUpdate BossUpdate = BossStatus[i].GetComponentInChildren<BossStatusUpdate> ();
			BossUpdate.StatusUpdate (max);
		}
	}

	public void DisableBossProgress(int maxhealth) {
		GameObject [] BossHP = ObjectStore.FindBossHP ();
		for (int i = 0; i < BossHP.Length; ++i) {
			BossHPUpdate BossUpdate = BossHP[i].GetComponentInChildren<BossHPUpdate> ();
			BossUpdate.DisableBossProgress (maxhealth);
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
