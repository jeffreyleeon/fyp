using UnityEngine;
using System.Collections;

public sealed class StatisticsStore : MonoBehaviour {

	private static StatisticsStore instance = new StatisticsStore ();

	// Variables related to statistics

	private StatisticsStore () {
		ResetStat ();
	}

	public static StatisticsStore GetInstance () {
		return instance;
	}

	public void ResetStat () {
	
	}

}
