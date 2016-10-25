using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FYP.Score;

public abstract class ScoreObserver : MonoBehaviour {

	public abstract void UpdateScore (int new_score);
}

public class ScoreText : ScoreObserver {

	public Text txt;
	private int score = 0;

	void Start(){
		Scoreboard.AddObserver (this);
		UpdateScore (score);
	}

	void OnDestroy () {
		Scoreboard.RemoveObserver (this);
	}

	public override void UpdateScore (int newScore)
	{
		score = newScore;
		txt.text = score.ToString();
	}

}
