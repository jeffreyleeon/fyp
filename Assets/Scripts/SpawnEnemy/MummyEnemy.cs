﻿using UnityEngine;
using System.Collections;

public class MummyEnemy : WalkingEnemy {

	void Awake () {
		control_script controlScript = GetComponent<control_script> ();
		controlScript.Run ();
	}

}