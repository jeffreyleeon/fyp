using UnityEngine;
using System.Collections;

public class Knife : Bullet {

	[Tooltip("Revolutions the knife will rotate per second")]
	public int rotationsPerSec;

	void Start () {
		transform.Rotate(-90.0f, 0.0f, 0.0f);
	}

	void Update () {
		transform.Rotate(rotationsPerSec * 6.0f * Time.deltaTime, 0.0f, 0.0f);
	}

}
