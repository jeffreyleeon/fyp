using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	[Tooltip("Array of game object: 'Enemy'")]
	public GameObject[] enemies;

	//the current amount of enemies on screen
	[Tooltip("Current amount of enemier")]
	public int amount;

	[Tooltip("Max no. of enemies that appear at the same time")]
	public int maxEnemy = 10;

	[Tooltip("Boundary of X-cor that an enemy appear")]
	public int minX = -8;
	[Tooltip("Boundary of X-cor that an enemy appear")]
	public int maxX = 8;
	[Tooltip("Boundary of Y-cor that an enemy appear")]
	public int minY = 0;
	[Tooltip("Boundary of Y-cor that an enemy appear")]
	public int maxY = 1;
	[Tooltip("Boundary of Z-cor that an enemy appear")]
	public int minZ = -2;
	[Tooltip("Boundary of Z-cor that an enemy appear")]
	public int maxZ = 2;

	[Tooltip("Min time for new enemy to appear")]
	public int minSpawnTime = 1;
	[Tooltip("Max time for new enemy to appear")]
	public int maxSpawnTime = 5;

	[Tooltip("Prefab of the enemy spawn")]
	public GameObject enemyPrefab;

	private Vector3 spawnPoint;

	void Start () {
		SpawnEnemy ();
	}

	void SpawnEnemy() {
		spawnPoint.x = Random.Range (minX, maxX);
		spawnPoint.y = Random.Range (minY, maxY);
		spawnPoint.z = Random.Range (minZ, maxZ);
	
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		amount = enemies.Length + 1;
		if (amount < maxEnemy) {
			Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
		}
		Invoke ("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
	}
}
