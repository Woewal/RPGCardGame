using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public void Initiate(PlayerInfo player)
	{
		GetComponent<PlayerCharacterMovement>().Initiate(player);
	}
}
