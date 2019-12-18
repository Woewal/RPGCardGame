using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPlayerColor : MonoBehaviour
{
	[SerializeField] PlayerCharacter playerCharacter;
	[SerializeField] List<MeshRenderer> meshRenderer;

	void Start()
	{
		for (int i = 0; i < meshRenderer.Count; i++)
		{
			meshRenderer[i].materials[0].SetColor("_BaseColor", playerCharacter.Info.Color);	
		}
	}
}
