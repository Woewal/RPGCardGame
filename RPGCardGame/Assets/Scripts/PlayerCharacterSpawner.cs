using UnityEngine;
using System.Collections;

public class PlayerCharacterSpawner : MonoBehaviour
{
	[SerializeField] PlayerCharacter playerCharacterPrefab;
	
	void Start()
	{
		PlayerManager.Instance.OnPlayerAdded += EnableSpawning;
	}

	void EnableSpawning(PlayerInfo player)
	{
		StartCoroutine(WaitPlayerReady(player));
	}

	IEnumerator WaitPlayerReady(PlayerInfo player)
	{
		while (player.Cursor == null) yield return null;

		player.Cursor.OnCast = (position) =>
		{
			var character = Instantiate(playerCharacterPrefab);
			character.transform.position = position;
			character.Initiate(player);
		};
	}
}
