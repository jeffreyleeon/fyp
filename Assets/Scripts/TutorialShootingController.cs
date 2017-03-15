using UnityEngine;
using System.Collections;

public class TutorialShootingController : ShootingController {
	
	[Tooltip("Prefab of secondary bullet type for teaching player to change weapon")]
	public GameObject secondaryBulletPrefab;

	private bool changedWeapon = false;

	private string originalWeaponName = null;

	override protected void ChangeWeapon () {
		if (originalWeaponName == null) {
			changedWeapon = true;
			originalWeaponName = bulletPrefab.gameObject.name;
		}
		GameObject temp = bulletPrefab;
		bulletPrefab = secondaryBulletPrefab;
		secondaryBulletPrefab = temp;
	}

	public bool HasChangedWeapon () {
		return changedWeapon && secondaryBulletPrefab.gameObject.name == originalWeaponName;
	}

}
