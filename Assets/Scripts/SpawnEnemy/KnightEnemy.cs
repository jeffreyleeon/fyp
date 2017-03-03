using UnityEngine;
using System.Collections;

public class KnightEnemy : WalkingEnemy {

	Animator anim;
	int jumpHash = Animator.StringToHash("Jump");
	int walkHash = Animator.StringToHash("Walk");
	int dieHash = Animator.StringToHash("Die");
	int count = 0;

	// Use this for initialization
	virtual public void Start () {
		base.Start ();
		anim = GetComponent<Animator>();
		transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
	}
	
	// Update is called once per frame
	virtual public void Update () {
		base.Update ();
		if (!IsAlive ()) {
			return;
		}
		if (count % 360 < 100) {
			anim.SetTrigger (jumpHash);
		} else {
			anim.SetTrigger (walkHash);
		}
		count++;
	}

	public override void RunDieAnimation () {
		anim.ResetTrigger (jumpHash);
		anim.ResetTrigger (walkHash);
		anim.SetTrigger (dieHash);
	}

}
