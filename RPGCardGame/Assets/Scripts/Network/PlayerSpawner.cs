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
		for (int i = 0; i < NetworkServer.connections.Count; i++)
		{
			var player = Instantiate(PlayerPrefab);
			NetworkServer.SpawnWithClientAuthority(player, NetworkServer.connections[i].playerController);
		}
    }
}
