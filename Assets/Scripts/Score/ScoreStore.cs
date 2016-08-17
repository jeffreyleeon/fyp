using UnityEngine;
using System.Collections;

/*
 * ScoreStore deal with players' score for local game and online game
 */
public sealed class ScoreStore{

	private static ScoreStore instance = new ScoreStore();
	private string singlePlayerKey = "SINGLE_PLAYER_KEY";

	private ScoreStore () {
	}

	public static ScoreStore GetInstance () {
		return instance;
	}

	public void SetScore (float score) {
		PlayerPrefs.SetFloat (singlePlayerKey, score);
	}

	public float GetScore () {
		return PlayerPrefs.GetFloat (singlePlayerKey, 0.0f);
	}

	// TODO: Deal with online game, score from server
	// TODO: Deal with multi-player game (Optional)
}
