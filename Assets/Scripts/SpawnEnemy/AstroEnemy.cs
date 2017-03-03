using UnityEngine;
using System.Collections;

public class AstroEnemy : WalkingEnemy {

	Animator anim;
	string swimHash = "Swim 02";
	string idleHash = "Idle 02";
	string dieHash = "Fall 01";

	// Use this for initialization
	virtual public void Start () {
		base.Start ();
		// initialising reference variables
		anim = gameObject.GetComponent<Animator>();	
		if (!isIdle) {
			transform.rotation = Quaternion.AngleAxis (180, Vector3.up);

			anim.Play (swimHash);
		} else {
			anim.Play (idleHash);
		}
	}

	// Update is called once per frame
	virtual public void Update () {
		base.Update ();
	}

	public override void RunDieAnimation () {
		anim.Play (dieHash);
	}
}