using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {

	private Text txt;

	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();
		txt.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Hello";
	}
}
