using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHPUpdate : MonoBehaviour {

	public GameObject bossBar;
	public RectTransform hpBar;
	public float maxRectWidth;

	// Use this for initialization
	void Start () {
		maxRectWidth = hpBar.rect.width;
	}

	void Update () {
		if (bossBar.GetActive () == true) {
			return;
		}
		float maxHP = ObjectStore.GetBossMaxHP ();
		float currentHP = ObjectStore.GetBossCurrentHP ();
		float hpBarRatio = (currentHP / (float)maxHP) * maxRectWidth;
		hpBar.sizeDelta = new Vector2 (Mathf.Clamp (hpBarRatio, 0, maxRectWidth), hpBar.rect.height);
	}

	public void DisableBossProgress(int maxhealth){
		bossBar.SetActive (false);
	}
}