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
	public void StatusUpdate (int max) {
		float progress = (1 / (float)max) * bossBar.rect.width;
		Vector3 bossLocalPos = boss.localPosition;
		boss.localPosition = new Vector3 (bossLocalPos.x - progress, bossLocalPos.y, bossLocalPos.z);
	}
}
