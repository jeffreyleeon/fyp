using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHPUpdate : MonoBehaviour {

	public GameObject bossBar;
	public RectTransform hpBar;
	public float currHP;
	public int maxHP;
	public float maxRectWidth;
	Player player;

	// Use this for initialization
	void Start () {
		maxRectWidth = hpBar.rect.width;
	}

	// Update is called once per frame
	public void UpdateBossHP (float damage) {
		currHP = currHP - damage;
		float hpBarRatio = (currHP / (float)maxHP) * maxRectWidth;
		hpBar.sizeDelta = new Vector2 (Mathf.Clamp (hpBarRatio, 0, maxRectWidth), hpBar.rect.height);
	}

	public void DisableBossProgress(int maxhealth){
		bossBar.SetActive (false);
		maxHP = maxhealth;
		currHP = (float) maxHP;
		Debug.Log ("Boss Health == " + maxHP);
	}
}