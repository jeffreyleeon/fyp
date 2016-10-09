using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[Tooltip("Damage it can deal")]
	public int attack = 20;

	//public for debugging, will be private
	public string owner;

	public void SetOwner(string ownerName){
		owner = ownerName;
	}

	public int Attack {
		get {
			return attack;
		}
	}
}
