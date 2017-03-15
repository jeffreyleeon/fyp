using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingBar : MonoBehaviour {

	public Transform loadingBar;
	public static float currentAmount = 0;
	public static int thershold = 60;

	public static void SetMax (int newThershold) {
		thershold = newThershold;
	}

	// Update is called once per frame
	void Update () {
		loadingBar.GetComponent<Image> ().fillAmount = currentAmount / thershold;
	}
}
