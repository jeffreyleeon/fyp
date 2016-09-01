using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class Bullet : Photon.MonoBehaviour {

	[Tooltip("Damage it can deal")]
	public int attack = 100;


}
