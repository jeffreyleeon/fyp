using UnityEngine;
using System.Collections;

public sealed class StatisticsStore : MonoBehaviour {

	private static StatisticsStore instance = new StatisticsStore ();

	// Variables related to statistics
	private System.DateTime gameStartTime;

	private StatisticsStore () {
		ResetStat ();
	}

	public static StatisticsStore GetInstance () {
		return instance;
	}

	public void ResetStat () {
		gameStartTime = System.DateTime.Now;
	}

	public string GetStatistics () {
		string stat = "";
		stat += GetFormattedTime ();

		return stat;
	}

	#region game time

	public void SetGameStartTime (System.DateTime mTime) {
		gameStartTime = mTime;
	}

	private string GetFormattedTime () {
		string formattedTime = "Game Time: ";
		if (gameStartTime == null) {
			return formattedTime;
		}
		System.DateTime now = System.DateTime.Now;
		float deltaTime = Mathf.Floor((float)((now - gameStartTime).TotalSeconds));
		int minutes = (int)deltaTime / 60;
		int second = (int)deltaTime % 60;
		return formattedTime + minutes + " min " + second + " sec\n\n";
	}

	#endregion

}
