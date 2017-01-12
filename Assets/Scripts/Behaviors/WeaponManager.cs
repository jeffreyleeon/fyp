using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

}

public interface IWeapon {
	Constants.WeaponType WeaponType ();
	void SetShootingController ();
}

public class BulletBehv : MonoBehaviour, IWeapon{
	public Constants.WeaponType WeaponType () {
		return Constants.WeaponType.Bullet;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("Bullet") as GameObject;
		shootControler.numOfBulletPerSecond = 10;
	}
}

public class KnifeBehv : MonoBehaviour, IWeapon{
	public Constants.WeaponType WeaponType () {
		return Constants.WeaponType.Knife;
	}

	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("BloodyKnife") as GameObject;
		shootControler.numOfBulletPerSecond = 5;

	}
}