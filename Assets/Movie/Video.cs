using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Video : MonoBehaviour {

	public MovieTexture movie;
	private AudioSource audio;

	private bool started = false;

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
		CheckEndOfTrailor ();
	}

	void ListenKeyboard () {
		if (Input.GetKey (KeyCode.P)) {
			movie.Play ();
			audio.Play ();
			started = true;
		}
	}

	void CheckEndOfTrailor () {
		if (started == true && !movie.isPlaying) {
			ChangeScene.ChangeToScene (ChangeScene.MENU_SCENE);
			Destroy (this.gameObject, 0.5f);
			started = false;
		}
	}
}
