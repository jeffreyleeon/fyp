using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Video : MonoBehaviour {

	public MovieTexture movie;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		Renderer renderer = GetComponent<Renderer> ();
		audio = GetComponent<AudioSource> ();
		audio.clip = movie.audioClip;
		renderer.material.mainTexture = movie as MovieTexture;
		// movie.Play ();
		// audio.Play ();
	}

	void Update () {
		ListenKeyboard ();
	}

	void ListenKeyboard () {
		if (Input.GetKey (KeyCode.P)) {
			movie.Play ();
			audio.Play ();
		}
	}
}
