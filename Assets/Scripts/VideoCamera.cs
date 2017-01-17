using UnityEngine;
using System.Collections;

public class VideoCamera : MonoBehaviour {

	public Transform from;
	public Transform to;
	public float speed = 0.001F;
	private float startedTime;

	private bool started = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && !started) {
			started = true;
			startedTime = Time.time;
		}
		if (started) {
			Action ();
		}
	}

	void Action () {
		// transform.position = Quaternion.Lerp (from.position, to.position, (Time.time - startedTime) * speed);
		transform.rotation = Quaternion.Lerp (from.rotation, to.rotation, (Time.time - startedTime) * speed);
	}
}
