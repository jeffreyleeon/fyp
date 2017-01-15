using UnityEngine;
using System.Collections;

namespace MagicalFX
{
	public class PatchedSpawner : MonoBehaviour
	{
		public bool FixRotation = false;
		public bool Normal;
		public GameObject FXSpawn;
		public float LifeTime = 0;
		public float TimeSpawn = 0;
		private float timeTemp;

		void Start ()
		{
			timeTemp = Time.time;
			if (FXSpawn != null && TimeSpawn <= 0) {
				SpawnBullet ();
			}
		}

		void Update ()
		{
			if (TimeSpawn > 0) {
				if (Time.time > timeTemp + TimeSpawn) {
					timeTemp = Time.time;
					if (FXSpawn != null) {
						SpawnBullet ();
					}
				}
			}
		}

		void SpawnBullet () {
			Quaternion rotate = this.transform.rotation;
			if (!FixRotation)
				rotate = FXSpawn.transform.rotation;

			// Spawn bullet delegate back to shooting controller
			ShootingController shootControler =  ObjectStore.FindShootingManager ().GetComponent<ShootingController>();
			shootControler.SpawnMagicalLibraryOnDirectionBullet (FXSpawn.name, this.transform.position, rotate, this.transform.forward);
		}

	}
}
