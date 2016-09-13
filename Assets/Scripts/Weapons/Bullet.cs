using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[Tooltip("Damage it can deal")]
	public int attack = 100;

	//public for debugging, will be private
	public string owner;

	public void setOwner(string ownerName){
		owner = ownerName;
	}
}
