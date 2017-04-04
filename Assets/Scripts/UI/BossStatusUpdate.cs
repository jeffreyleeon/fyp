using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossStatusUpdate : MonoBehaviour {

	public RectTransform bossBar;
	public RectTransform boss;
	private float maxRectWidth;

	// Use this for initialization
	void Start () {
		maxRectWidth = boss.anchoredPosition.x;
	}

	// Update is called once per frame
	public void StatusUpdate (int remaining, int max) {
		if (remaining != 0) {
			float progress = (1 / (float)max) * maxRectWidth;
			Debug.Log ("======Translate is " + progress);
			boss.Translate (-progress, 0, 0);
		} else {
			DisableBossUpdate ();
		}
	}

	void DisableBossUpdate () {
		
	}
}
