using UnityEngine;
using System.Collections;

public class SceneWeaponsList : MonoBehaviour {

	[Tooltip("Weapons for specific game scene")]
	public WeaponManager.WeaponType[] weaponsList = new WeaponManager.WeaponType[] {
		WeaponManager.WeaponType.Bullet,
		WeaponManager.WeaponType.Knife,
		WeaponManager.WeaponType.LightingShot,
		WeaponManager.WeaponType.FireFissure,
		WeaponManager.WeaponType.DarkMissile,
		WeaponManager.WeaponType.FireRock,
		WeaponManager.WeaponType.IceWave,
		WeaponManager.WeaponType.LightingFissure,
	};

}
