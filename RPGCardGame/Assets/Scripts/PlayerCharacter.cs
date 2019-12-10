using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	public PlayerCharacterMovement Movement;
	public PlayerInfo Info;
	public List<Renderer> MeshRenderers;

    public void Initiate(PlayerInfo player)
	{
		Movement = GetComponent<PlayerCharacterMovement>();
		Movement.Initiate(player);
		Info = player;
		for (int i = 0; i < MeshRenderers.Count; i++)
		{
			MeshRenderers[i].material.SetColor("_BaseColor", player.Color);
		}
	}
}
