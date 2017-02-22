using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	[Tooltip("Array of game object: 'Enemy'")]
	public GameObject[] enemies;

	[Tooltip("Prefab of the big boss")]
	public GameObject boss;

	[Tooltip("Amount of enemies to be spawned before spawning big boss")]
	public int enemiesRemaining = 20;

	[Tooltip("Max no. of enemies that appear at the same time")]
	public int maxEnemy = 10;

	[Tooltip("Boundary of X-cor that an enemy appear")]
	public int minX = -20;
	[Tooltip("Boundary of X-cor that an enemy appear")]
	public int maxX = 20;
	[Tooltip("Boundary of Y-cor that an enemy appear")]
	public int minY = -10;
	[Tooltip("Boundary of Y-cor that an enemy appear")]
	public int maxY = 10;
	[Tooltip("Boundary of Z-cor that an enemy appear")]
	public int minZ = 30;
	[Tooltip("Boundary of Z-cor that an enemy appear")]
	public int maxZ = 40;

	[Tooltip("Min time for new enemy to appear")]
	public int minSpawnTime = 1;
	[Tooltip("Max time for new enemy to appear")]
	public int maxSpawnTime = 5;

	private Vector3 spawnPoint;

	void Start () {
		if (PhotonNetwork.isMasterClient) {
			Debug.Log ("MasterClient!");
			SpawnEnemy ();
		}
	}

	void SpawnEnemy() {
		if (enemiesRemaining <= 0) {
			SpawnBoss ();
			return;
		}
		spawnPoint.x = Random.Range (minX, maxX);
		spawnPoint.y = Random.Range (minY, maxY);
		spawnPoint.z = Random.Range (minZ, maxZ);
	
		GameObject[] existingEnemies = ObjectStore.FindEnemies ();
		int amount = existingEnemies.Length + 1;
		if (amount < maxEnemy) {
			int index = Random.Range (0, enemies.Length);
			PhotonNetwork.Instantiate(enemies [index].gameObject.name, spawnPoint, Quaternion.identity, 0);
			enemiesRemaining--;
		}
		Invoke ("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
	}

	void SpawnBoss () {
		Vector3 point = new Vector3 (0, maxY, maxZ);
		PhotonNetwork.Instantiate(boss.gameObject.name, point, Quaternion.identity, 0);
	}
}
