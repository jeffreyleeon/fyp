using UnityEngine;
using System.Collections;

public class Trinus : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad (this.gameObject);
	}
}
