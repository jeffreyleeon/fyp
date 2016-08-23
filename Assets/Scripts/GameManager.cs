using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{
	GameObject trinus;
	GameObject player;
	GameObject enemyManager;

	void Awake(){
		trinus = GameObject.Find ("Trinus");
		enemyManager = GameObject.Find ("EnemyManager");

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
}
