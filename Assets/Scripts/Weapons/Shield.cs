using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Renderer r = gameObject.AddComponent<MeshRenderer>() as Renderer;
		Shader s = Shader.Find ("Unlit/Transparent");
		r.material = new Material(s);
	}

}
