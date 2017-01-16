using UnityEngine;
using System.Collections;

public class AstroEnemy : WalkingEnemy {

	Animator anim;
	string swimHash = "Swim 02";
	int walkHash = Animator.StringToHash("Walk");
	int count = 0;

	// Use this for initialization
	virtual public void Start () {
		base.Start ();
		// initialising reference variables
		anim = gameObject.GetComponent<Animator>();					  
		transform.rotation = Quaternion.AngleAxis(180, Vector3.up);

		anim.Play (swimHash);
	}

	// Update is called once per frame
	virtual public void Update () {
		base.Update ();
	}
}