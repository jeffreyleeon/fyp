using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using FYP.Score;

public class EndScore : MonoBehaviour {

	public Text txt;
	public List<PlayerScore> playersScore;

	// Use this for initialization
	void Start () {
		
		txt.text = "";
		playersScore = Scoreboard.GetAllPlayerScore ();
		foreach (PlayerScore player in playersScore) {
			txt.text += player.name + "\t\t\t\t\t\t" + player.score + "\n";

		}
	}
	

}
