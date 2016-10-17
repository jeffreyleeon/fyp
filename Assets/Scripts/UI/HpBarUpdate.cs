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
		hpBar.sizeDelta = new Vector2( hpBar.rect.width - 0.2f, hpBar.rect.height);
		print ("Hehe================" + hpBar.rect.width);
	}
}
