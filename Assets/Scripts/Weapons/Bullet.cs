using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[Tooltip("Damage it can deal")]
	public int attack = 20;

	//public for debugging, will be private
	public string owner;

	[Tooltip("Initial speed of the bullet")]
	public float speed;

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
