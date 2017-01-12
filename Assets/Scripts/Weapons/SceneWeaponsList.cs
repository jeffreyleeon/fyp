using UnityEngine;
using System.Collections;

public class SceneWeaponsList : MonoBehaviour {

	[Tooltip("Weapons for specific game scene")]
	public Constants.WeaponType[] weaponsList = new Constants.WeaponType[] {
		Constants.WeaponType.Bullet,
		Constants.WeaponType.Knife,
	};

}
