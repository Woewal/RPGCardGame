using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	public PlayerCharacterMovement Movement;
	public PlayerInfo Info;
	public List<SkinnedMeshRenderer> MeshRenderers;

    public void Initiate(PlayerInfo player)
	{
		Movement = GetComponent<PlayerCharacterMovement>();
		Movement.Initiate(player);
		Info = player;
		//foreach(var meshRenderer in MeshRenderers)
		//{
		//	meshRenderer.material.color = player.Color;
		//}
	}
}
