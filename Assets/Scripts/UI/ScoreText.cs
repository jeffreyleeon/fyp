using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {

	public Text txt;
	private int score = 0;
	
	void Update () {
//		score = Scoreboard.GetLocalPlayerScore ();
		txt.text = score.ToString ();
	}
}
