using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBarUpdate : MonoBehaviour {

	public RectTransform hpBar;
	private int Hp = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		hpBar.sizeDelta = new Vector2(Mathf.Clamp(hpBar.rect.width - 0.2f, 0, 100), hpBar.rect.height);
	}
}
