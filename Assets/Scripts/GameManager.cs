using UnityEngine;
using System.Collections;

public class GameManager : Photon.PunBehaviour {
	GameObject trinus;
	GameObject player;
	GameObject enemyManager;

	void Awake(){
		trinus = GameObject.Find ("Trinus");
		enemyManager = GameObject.Find ("EnemyManager");

		NetworkManager.InitConfig ();
		NetworkManager.ConnectServer ();
	}

	// Use this for initialization
	void Start () {
		player = PhotonNetwork.Instantiate ("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
		trinus.transform.parent = player.transform;
		enemyManager.GetComponent<Spawn> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region PUN callbacks

	override public void OnFailedToConnectToPhoton (DisconnectCause cause) {
		Debug.LogError ("FYP/OnFailedToConnectToPhoton " + cause);
		Debug.LogError ("Please check network connection and app id");
	}

	override public void OnConnectionFail (DisconnectCause cause) {
		Debug.LogError ("FYP/OnConnectionFail " + cause);
		Debug.LogError ("Please check network region and CCU limit");
	}

	#endregion
}
