using UnityEngine;
using System.Collections;

public class BadWizardEnemy  : WalkingEnemy {

	Animator anim;
	string walkHash = "Chubby 01 Walk";
	string idleHash = "Idle 02";

	// Use this for initialization
	virtual public void Start () {
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
}
