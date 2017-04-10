using UnityEngine;
using System.Collections;

public class PresentIcon : MonoBehaviour {

	float baseX;

	// Use this for initialization
	void Start () {
		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x + 90,
			transform.eulerAngles.y + 180,
			transform.eulerAngles.z
		);
		baseX = transform.position.x;
	}

	void Update () {
		Vector3 currentPosition = transform.position;
		float frequency = 2f;
		float delta = 0.5f * Mathf.Sin (2 * Mathf.PI * frequency * Time.time);
		transform.position = new Vector3(baseX + delta, currentPosition.y + 0.05f, currentPosition.z);
	}

	public void SetIcon (string filePath) {
		string _filePath = filePath;
		if (!Resources.Load(_filePath)) {
			Debug.Log ("FYP/PresentIcon/SetIcon: Invalid file path");
			return;
		}
		Texture texture = Resources.Load(_filePath) as Texture;
		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.mainTexture = texture;
	}

}
