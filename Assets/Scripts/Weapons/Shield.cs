using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Renderer r = gameObject.AddComponent<MeshRenderer>() as Renderer;
		Shader s = Shader.Find ("Unlit/Transparent");
//		Shader s = Shader.Find ("Transparent/Diffuse");
		r.material = new Material(s);
		r.material.color = new Color (1, 1, 1, 0.5f);
	}

}
