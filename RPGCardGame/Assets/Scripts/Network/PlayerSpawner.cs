using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSpawner : MonoBehaviour
{
	public GameObject PlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
		foreach(var entry in NetworkServer.connections)
		{
			StartCoroutine(WaitForReady(entry.Value));
		}
    }

	IEnumerator WaitForReady(NetworkConnection networkConnection)
	{
		while (!networkConnection.isReady)
			yield return null;

		var player = Instantiate(PlayerPrefab);
		NetworkServer.SpawnWithClientAuthority(player, networkConnection);
	}
}
