using UnityEngine;
using System.Collections;

public class TutorialShootingController : ShootingController {
	
	[Tooltip("Prefab of secondary bullet type for teaching player to change weapon")]
	public GameObject secondaryBulletPrefab;

	override protected void ChangeWeapon () {
		GameObject temp = bulletPrefab;
		bulletPrefab = secondaryBulletPrefab;
		secondaryBulletPrefab = temp;
	}

}
