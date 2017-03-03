using UnityEngine;
using System.Collections;

public class WoodEnemy : WalkingEnemy {

	Animator anim;
	string walkHash = "Walk 06";
	string idleHash = "Idle 02";
	string dieHash = "Fall 03";

	// Use this for initialization
	void Start () {
		base.Start ();
		// initialising reference variables
		anim = gameObject.GetComponent<Animator>();

		transform.rotation = Quaternion.AngleAxis (180, Vector3.up);
		string action = GetInitialAction ();
		anim.Play (action);
	}
	
	string GetInitialAction () {
		string ret = idleHash;

		if (!isIdle) {
			ret = walkHash;
		}

		return ret;
	}

	// Update is called once per frame
	virtual public void Update () {
		base.Update ();
	}

	public override void RunDieAnimation () {
		anim.Play (dieHash);
	}

}