using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectSpawner : MonoBehaviour
{
	public void SpawnObject(GameObject prefab)
	{
		var newGameObject = Instantiate(prefab);
		newGameObject.transform.position = transform.position;
		newGameObject.transform.rotation = transform.rotation;
	}
}
