using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	static public string weaponIconBasePath = "Assets/UI/";
	static public string defaultWeaponIconFilePath = "Assets/UI/weapon_bullet.png";
	public enum WeaponType {
		Bullet,
		Knife
	}
}

public interface IWeapon {
	WeaponManager.WeaponType WeaponType ();
	void SetShootingController ();
}

public class BulletBehv : MonoBehaviour, IWeapon{
	public WeaponManager.WeaponType WeaponType () {
		return WeaponManager.WeaponType.Bullet;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("Bullet") as GameObject;
		shootControler.numOfBulletPerSecond = 10;
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "weapon_bullet.png");
	}
}

public class KnifeBehv : MonoBehaviour, IWeapon{
	public WeaponManager.WeaponType WeaponType () {
		return WeaponManager.WeaponType.Knife;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("BloodyKnife") as GameObject;
		shootControler.numOfBulletPerSecond = 5;
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "weapon_knife.png");
	}
}