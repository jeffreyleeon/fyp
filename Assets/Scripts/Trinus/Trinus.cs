using UnityEngine;
using System.Collections;

public class Trinus : MonoBehaviour {

	void Awake () {
		if (!ObjectStore.FindTrinus ().Equals(this.gameObject)) {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
