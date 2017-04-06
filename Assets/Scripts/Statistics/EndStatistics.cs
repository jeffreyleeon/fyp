using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndStatistics : MonoBehaviour {

	public TextMesh txt;

	// Use this for initialization
	void Start () {
		txt.text = "";
		StatisticsStore store = StatisticsStore.GetInstance ();
		string statistics = store.GetStatistics ();
		txt.text += statistics;
	}
}
