using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	[Tooltip("Array of game object: 'Enemy'")]
	public GameObject[] enemies;

	//the current amount of enemies on screen
	[Tooltip("Current amount of enemies")]
	public int amount;

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

	[Tooltip("Prefab name of the enemy spawn")]
	public string enemyPrefabName = "Enemy";

	private Vector3 spawnPoint;

	void Start () {
		if (PhotonNetwork.isMasterClient) {
			Debug.Log ("MasterClient!");
			SpawnEnemy ();
		}
	}

	void SpawnEnemy() {
		spawnPoint.x = Random.Range (minX, maxX);
		spawnPoint.y = Random.Range (minY, maxY);
		spawnPoint.z = Random.Range (minZ, maxZ);
	
		enemies = ObjectStore.FindEnemies ();
		amount = enemies.Length + 1;
		if (amount < maxEnemy) {
			PhotonNetwork.Instantiate(enemyPrefabName, spawnPoint, Quaternion.identity, 0);
		}
		Invoke ("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
	}
}
