using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCharacterSpawner : MonoBehaviour
{
	[SerializeField] PlayerCharacter playerCharacterPrefab;
	[SerializeField] List<GameObject> spawnPoints;

	void Start()
	{
		PlayerManager.Instance.OnPlayerAdded += Spawn;
	}

	void Spawn(PlayerInfo playerInfo)
	{
		var playerCharacter = Instantiate(playerCharacterPrefab);
		transform.position = spawnPoints[PlayerManager.Instance.Players.Count - 1].transform.position;
		transform.rotation = spawnPoints[PlayerManager.Instance.Players.Count - 1].transform.rotation;
		playerCharacter.Initiate(playerInfo);
		CursorManager.Instance.RegisterCursor(playerInfo);
	}
}
