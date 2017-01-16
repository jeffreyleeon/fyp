using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	static public string weaponIconBasePath = "WeaponsIcon/";
	static public string defaultWeaponIconFilePath = "WeaponsIcon/weapon_bullet";
	public enum WeaponType {
		Bullet,
		Knife,
		LightingShot,
		FireFissure,
		DarkMissile,
		FireRock,
		IceWave,
		FireBurn,
		LightingFissure,
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
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "weapon_bullet");
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
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "weapon_knife");
	}
}

public class LightingShotBehv : MonoBehaviour, IWeapon {
	public WeaponManager.WeaponType WeaponType () {
		return WeaponManager.WeaponType.LightingShot;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("LightingShot") as GameObject;
		shootControler.numOfBulletPerSecond = 3;
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "weapon_bg"); // TODO: Update image when it is ready
	}
}

public class FireFissureBehv : MonoBehaviour, IWeapon {
	public WeaponManager.WeaponType WeaponType () {
		return WeaponManager.WeaponType.FireFissure;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("FireFissure") as GameObject;
		shootControler.numOfBulletPerSecond = 1;
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "loading"); // TODO: Update image when it is ready
	}
}

public class DarkMissileBehv : MonoBehaviour, IWeapon {
	public WeaponManager.WeaponType WeaponType () {
		return WeaponManager.WeaponType.DarkMissile;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("DarkMissile") as GameObject;
		shootControler.numOfBulletPerSecond = 5;
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "loading"); // TODO: Update image when it is ready
	}
}

public class FireRockBehv : MonoBehaviour, IWeapon {
	public WeaponManager.WeaponType WeaponType () {
		return WeaponManager.WeaponType.FireRock;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("FireRock") as GameObject;
		shootControler.numOfBulletPerSecond = 2;
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "loading"); // TODO: Update image when it is ready
	}
}

public class IceWaveBehv : MonoBehaviour, IWeapon {
	public WeaponManager.WeaponType WeaponType () {
		return WeaponManager.WeaponType.IceWave;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("IceWave") as GameObject;
		shootControler.numOfBulletPerSecond = 6;
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "loading"); // TODO: Update image when it is ready
	}
}

public class FireBurnBehv : MonoBehaviour, IWeapon {
	public WeaponManager.WeaponType WeaponType () {
		return WeaponManager.WeaponType.FireBurn;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("FireBurn") as GameObject;
		shootControler.numOfBulletPerSecond = 10;
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "loading"); // TODO: Update image when it is ready
	}
}

public class LightingFissureBehv : MonoBehaviour, IWeapon {
	public WeaponManager.WeaponType WeaponType () {
		return WeaponManager.WeaponType.LightingFissure;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("LightingFissure") as GameObject;
		shootControler.numOfBulletPerSecond = 1;
		shootControler.UpdateWeaponIcon (WeaponManager.weaponIconBasePath + "loading"); // TODO: Update image when it is ready
	}
}