using UnityEngine;
using System.Collections;

public class GameManager : Photon.PunBehaviour {

	void Start () {
		NetworkManager.InitConfig ();
	}
}
