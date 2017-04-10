using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	Renderer r;
	float baseAlpha;

	// Use this for initialization
	void Start () {
		r = gameObject.AddComponent<MeshRenderer>() as Renderer;
		Shader s = Shader.Find ("Unlit/Transparent");
		r.material = new Material(s);
		baseAlpha = r.material.GetFloat ("_Alpha");
	}

	void Update () {
		float frequency = 0.5f;
		float delta = 0.05f * Mathf.Sin (2 * Mathf.PI * frequency * Time.time);
		r.material.SetFloat ("_Alpha", baseAlpha + delta);
	}

}
