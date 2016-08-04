using UnityEngine;
using System.Collections;

public class DummyParticle : MonoBehaviour {

	Vector3 initialPos;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")) {
			print("Up key is held down");
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			transform.position = initialPos;
		}
	}
}
