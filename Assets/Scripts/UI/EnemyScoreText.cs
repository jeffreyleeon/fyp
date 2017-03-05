using UnityEngine;
using System.Collections;

public class EnemyScoreText : MonoBehaviour {

	void Update () {
		Vector3 currentPosition = transform.position;
		transform.position = new Vector3(currentPosition.x, currentPosition.y + 0.05f, currentPosition.z);
	}
}
