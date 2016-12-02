using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBarUpdate : MonoBehaviour {

	public RectTransform hpBar;
	public int currHP;
	public int maxHP = 100;
	public float maxRectWidth;

	// Use this for initialization
	void Start () {
		currHP = maxHP;
		maxRectWidth = hpBar.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		float hpBarRatio = ((float)currHP / (float)maxHP) * maxRectWidth;
		hpBar.sizeDelta = new Vector2(Mathf.Clamp(hpBarRatio, 0, maxRectWidth), hpBar.rect.height);
	}
}
