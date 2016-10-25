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

	public bool IsOwnBy(string name){
		return (owner == name);
	}

	public int Attack {
		get {
			return attack;
		}
	}
}
