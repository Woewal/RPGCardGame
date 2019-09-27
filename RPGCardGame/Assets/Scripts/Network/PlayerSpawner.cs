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
		Debug.Log(NetworkServer.connections.Count);

		foreach(var entry in NetworkServer.connections)
		{
			var player = Instantiate(PlayerPrefab);
			NetworkServer.SpawnWithClientAuthority(player, entry.Value);
		}
    }
}
