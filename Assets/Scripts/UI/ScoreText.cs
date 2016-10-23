﻿using UnityEngine;
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
	}

	public override void UpdateScore (int new_score)
	{
		score = new_score;
		txt.text = score.ToString();
	}

}
