﻿using UnityEngine;
using System.Collections;

public class Frey : WalkingEnemy {

	Animator anim;
	int walkHash = Animator.StringToHash("Walk 02");
	string idleHash = "Sit 01";
	int count = 0;

	// Use this for initialization
	virtual public void Start () {
		base.Start ();
		// initialising reference variables
		anim = gameObject.GetComponent<Animator>();	
		if (!isIdle) {
			transform.rotation = Quaternion.AngleAxis (180, Vector3.up);

			anim.Play (walkHash);
		} else {
			anim.Play (idleHash);
		}
	}

	// Update is called once per frame
	virtual public void Update () {
		base.Update ();
	}
}