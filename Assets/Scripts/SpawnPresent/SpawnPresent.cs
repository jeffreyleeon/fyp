using UnityEngine;
using System.Collections;

public class SpawnPresent : MonoBehaviour {

	[Tooltip("Prefab of the present")]
	public GameObject present;

	[Tooltip("The probability of spawning a present (0 <= x <= 1)")]
	public float spawningProbability = 0.05f;

	[Tooltip("Boundary of X-cor that an enemy appear")]
	public int minX = -20;
	[Tooltip("Boundary of X-cor that an enemy appear")]
	public int maxX = 20;
	[Tooltip("Boundary of Z-cor that an enemy appear")]
	public int minZ = 30;
	[Tooltip("Boundary of Z-cor that an enemy appear")]
	public int maxZ = 40;

	public void spawn () {
		float prob = Random.Range (0.0f, 1.0f);
		if (prob > spawningProbability) {
			return;
		}
		Vector3 spawnPoint;
		spawnPoint.x = Random.Range (minX, maxX);
		spawnPoint.y = 5;
		spawnPoint.z = Random.Range (minZ, maxZ);
		PhotonNetwork.Instantiate(present.gameObject.name, spawnPoint, Quaternion.identity, 0);
	}
}
