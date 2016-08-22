using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{
	GameObject trinus;
	GameObject player;

	void Awake(){
		trinus = GameObject.Find ("Trinus");
	}

	// Use this for initialization
	void Start () {
		player = PhotonNetwork.Instantiate ("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
		trinus.transform.parent = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
