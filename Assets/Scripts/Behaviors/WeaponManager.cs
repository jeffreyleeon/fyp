using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

}

public interface IWeapon {
	void SetShootingController ();
}

public class BulletBehv : MonoBehaviour, IWeapon{
	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingController ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("Bullet") as GameObject;
		shootControler.numOfBulletPerSecond = 10;
	}
}

public class KnifeBehv : MonoBehaviour, IWeapon{
	public void SetShootingController (){
		ShootingController shootControler=  ObjectStore.FindShootingController ().GetComponent<ShootingController>();
		shootControler.bulletPrefab = (Object)Resources.Load("BloodyKnife") as GameObject;
		shootControler.numOfBulletPerSecond = 5;

	}
}