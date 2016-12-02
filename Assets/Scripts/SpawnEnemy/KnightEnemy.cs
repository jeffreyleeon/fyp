using UnityEngine;
using System.Collections;

public class KnightEnemy : WalkingEnemy {

	Animator anim;
	int jumpHash = Animator.StringToHash("Jump");
	int count = 0;

	// Use this for initialization
	virtual public void Start () {
		base.Start ();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	virtual public void Update () {
		base.Update ();
		if (count % 360 == 0) {
			anim.SetTrigger (jumpHash);
		}
		count++;
	}
}
