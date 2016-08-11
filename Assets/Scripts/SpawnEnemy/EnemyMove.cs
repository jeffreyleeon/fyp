﻿using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	private Transform track;
	[Tooltip("Game Object that the enemies move toward")]
	public GameObject trackObj = null;

	[Tooltip("Moving speed of enemy")]
	public float moveSpeed = 3f;

	[Tooltip("Height that the enemy jump")]
	public int jumpingForce = 750;

	[Tooltip("Boundary of X-cor that an enemy to destroy")]
	public int minX = -40;
	[Tooltip("Boundary of X-cor that an enemy to destroy")]
	public int maxX = 40;
	[Tooltip("Boundary of Y-cor that an enemy to destroy")]
	public int minY = -12;
	[Tooltip("Boundary of Y-cor that an enemy to destroy")]
	public int maxY = 40;
	[Tooltip("Boundary of Z-cor that an enemy to destroy")]
	public int minZ = 2;
	[Tooltip("Boundary of Z-cor that an enemy to destroy")]
	public int maxZ = 40; 

	// Use this for initialization
	void Start () {
		if (trackObj == null) {
			trackObj = GameObject.Find("Track");
		}
		track = trackObj.transform;
	}
	
	// Update is called once per frame
	void Update () {
		bool outOfBound = transform.position.x < minX || transform.position.x > maxX ||
						  transform.position.y < minY || transform.position.y > maxY ||
						  transform.position.z < minZ || transform.position.z > maxZ;
		if (outOfBound) {
			Destroy(gameObject);
		} else {
			float move = moveSpeed * Time.deltaTime;
//			transform.Translate(Vector3.up * jumpHeight * Time.deltaTime, Space.World);
			if (transform.position.y < minY + 3) {
				gameObject.GetComponent<Rigidbody> ().AddForce(new Vector3(0, jumpingForce, 0));
			}
			transform.position = Vector3.MoveTowards(transform.position, track.position, move);
		}
	}
}
