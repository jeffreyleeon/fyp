using UnityEngine;
using System.Collections;

public class DestroyOnDelay : MonoBehaviour {

	[Tooltip("Auto destroy object after delayTime(in second) count down ends")]
	public float delayTime;

	void Start () {
		if (delayTime < 0) {
			delayTime = 0.0f;
		}
		Destroy (gameObject, delayTime);
	}
}
