using UnityEngine;
using System.Collections;

public class ScoreStoreTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ScoreStore scoreStore = ScoreStore.GetInstance ();
		// Get the original score
		float backUpScore = scoreStore.GetScore ();
		print ("Original Score: " + backUpScore);

		// Reset the score
		scoreStore.ResetScore ();
		float score = scoreStore.GetScore ();
		print ("Score after reset: " + score);

		// Set the score and read again
		float dummyScore = 10.0f;
		scoreStore.SetScore (dummyScore);
		score = scoreStore.GetScore ();
		print ("Score after assigning manually: " + score);
		if (!float.Equals (score, dummyScore)) {
			Debug.LogWarning ("WARNING: ScoreStoreTest failed\nScore assigned: " + dummyScore + "\nScore read: " + score);
		}

		// Assign back original score
		scoreStore.SetScore (backUpScore);
		score = scoreStore.GetScore ();
		print ("Score after assigning back up score: " + score);
		if (!float.Equals (score, backUpScore)) {
			Debug.LogWarning ("WARNING: ScoreStoreTest failed\nScore assigned for back up: " + backUpScore + "\nScore read: " + score);
		}
	}
}
