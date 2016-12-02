using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBarUpdate : MonoBehaviour {

	public RectTransform hpBar;
	public int currHP;
	public int maxHP;
	public float maxRectWidth;
	Player player;

	// Use this for initialization
	void Start () {
		SetupPlayer ();
		maxRectWidth = hpBar.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			float hpBarRatio = ((float)player.GetCurrentHealth () / (float)player.maxHealth) * maxRectWidth;
			hpBar.sizeDelta = new Vector2 (Mathf.Clamp (hpBarRatio, 0, maxRectWidth), hpBar.rect.height);
		} else {
			SetupPlayer ();
		}
	}

	private void SetupPlayer(){
		player = ObjectStore.FindMyPlayer ();
	}
}
