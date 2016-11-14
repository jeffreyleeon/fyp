using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingBar : MonoBehaviour {

	public Transform loadingBar;
	public static float currentAmount = 0;

	// Update is called once per frame
	void Update () {
		loadingBar.GetComponent<Image> ().fillAmount = currentAmount / 60;
	}
}
