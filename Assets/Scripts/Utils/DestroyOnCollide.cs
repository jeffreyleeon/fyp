using UnityEngine;
using System.Collections;

public class DestroyOnCollide : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		Destroy (gameObject);
	}
}
