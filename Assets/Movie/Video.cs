using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Video : MonoBehaviour {

	public MovieTexture movie;

	// Use this for initialization
	void Start () {
		Renderer renderer = GetComponent<Renderer> ();
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = movie.audioClip;
		renderer.material.mainTexture = movie as MovieTexture;
		movie.Play ();
		audio.Play ();
	}
}
