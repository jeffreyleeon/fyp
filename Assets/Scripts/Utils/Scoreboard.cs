using UnityEngine;
using System.Collections;

public sealed class Scoreboard : MonoBehaviour {

	public static void  AddLocalPlayerScore(int score){
		PhotonNetwork.player.AddScore (score);
	}

	public static int GetLocalPlayerScore(){
		return PhotonNetwork.player.GetScore ();
	}

}
