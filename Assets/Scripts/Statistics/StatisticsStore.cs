using UnityEngine;
using System.Collections;

public sealed class StatisticsStore : MonoBehaviour {

	private static StatisticsStore instance = new StatisticsStore ();

	// Variables related to statistics
	private System.DateTime gameStartTime;
	private int enemyKilled;
	private float playerMaxHP;
	private float playerEndGameHP;
	private System.DateTime bossSpawnTime;
	private System.DateTime bossDieTime;


	private StatisticsStore () {
		ResetStat ();
	}

	public static StatisticsStore GetInstance () {
		return instance;
	}

	public void ResetStat () {
		gameStartTime = System.DateTime.Now;
		enemyKilled = 0;
		playerMaxHP = 0;
		playerEndGameHP = 0;
		bossSpawnTime = System.DateTime.Now;
		bossDieTime = System.DateTime.Now;
	}

	public string GetStatistics () {
		string stat = "";
		stat += GetFormattedTime ();
		stat += GetPlayerHPStat ();
		stat += GetEnemyKilled ();
		stat += GetBossKillTimeStat ();

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
		return formattedTime + minutes + " min " + second + " sec\n";
	}

	#endregion

	#region player HP

	public void SetPlayerMaxHP (float hp) {
		playerMaxHP = hp;
	}

	public void SetPlayerEndGameHP (float hp) {
		playerEndGameHP = hp;
	}

	private string GetPlayerHPStat () {
		int hpLost = (int)(playerMaxHP - playerEndGameHP);
		return "HP Lost: " + hpLost.ToString () + "\n";
	}

	#endregion

	#region enemy killed

	public void IncrementEnemyKilled () {
		enemyKilled++;
	}

	private string GetEnemyKilled () {
		return "Enemy Killed: " + enemyKilled + "\n";
	}

	#endregion

	#region boss killed

	public void SetBossSpawnTime () {
		bossSpawnTime = System.DateTime.Now;
	}

	public void SetBossDieTime () {
		bossDieTime = System.DateTime.Now;
	}

	private string GetBossKillTimeStat () {
		if (bossSpawnTime.Equals (bossDieTime)) {
			return "";
		}
		float deltaTime = Mathf.Floor((float)((bossDieTime - bossSpawnTime).TotalSeconds));
		if (deltaTime <= 0) {
			return "";
		}
		return "Kill Boss: " + deltaTime + " sec\n";
	}

	#endregion

}
