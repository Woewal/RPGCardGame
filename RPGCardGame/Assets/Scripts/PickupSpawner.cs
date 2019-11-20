using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
	[SerializeField] List<Pickup> pickupPrefabs;
	[SerializeField] float respawnTime;

	void Start()
	{
		StartRespawn();
	}

	void StartRespawn()
	{
		StartCoroutine(StartRespawnTimer());
	}

	IEnumerator StartRespawnTimer()
	{
		yield return new WaitForSeconds(respawnTime);
		Spawn();
	}

	void Spawn()
	{
		int random = Random.Range(0, pickupPrefabs.Count);
		var randomPickupPrefab = pickupPrefabs[random];

		var pickup = Instantiate(randomPickupPrefab);
		pickup.transform.position = transform.position;
		pickup.OnPickup += StartRespawn;
	}
}
