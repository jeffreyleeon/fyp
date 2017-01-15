using UnityEngine;
using System.Collections;

public class AlienEnemy : WalkingEnemy {

	Animator anim;
	int walkHash = Animator.StringToHash("Walk 02");
	int attackHash = Animator.StringToHash("Boxing 01");
	int count = 0;

	// Use this for initialization
	virtual public void Start () {
		base.Start ();
		// initialising reference variables
		anim = gameObject.GetComponent<Animator>();					  
		transform.rotation = Quaternion.AngleAxis(180, Vector3.up);

		anim.Play (walkHash);
	}

	// Update is called once per frame
	virtual public void Update () {
	}
}