using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	public PlayerCharacterMovement Movement;
	public PlayerInfo Info;

    public void Initiate(PlayerInfo player)
	{
		Movement = GetComponent<PlayerCharacterMovement>();
		Movement.Initiate(player);
		Info = player;
	}
}
