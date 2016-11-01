using UnityEngine;
using System.Collections;

public class WalkingEnemy : Enemy {

	[Tooltip("Degree of paddling per second")]
	public int paddlingDegree = 50;

	[Tooltip("Whether the enemy is rotating right direction")]
	private bool isRotatingRight = true;

	void Awake () {
		transform.Rotate(0, 0, paddlingDegree / 2);
		InvokeRepeating("SwitchRotatingDirection", 0, 1);
	}

	void SwitchRotatingDirection () {
		isRotatingRight = !isRotatingRight;
	}

	/// <summary>
	/// Move this object.
	/// </summary>
	override protected void Move() {
		float degree = Time.deltaTime * paddlingDegree;
		if (!isRotatingRight) {
			degree *= -1;
		}
		base.Move ();
		transform.Rotate(0, 0,  degree);
	}
}
