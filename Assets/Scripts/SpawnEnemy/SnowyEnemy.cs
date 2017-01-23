using UnityEngine;
using System.Collections;

public class SnowyEnemy : WalkingEnemy {

	Animator anim;
	//string swimHash = "Swim 02";
	string idleHash = "Idle 02";
	string walkHash = "Run 01";
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
