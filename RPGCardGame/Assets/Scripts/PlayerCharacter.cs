using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	public PlayerInfo Info;

    public void Initiate(PlayerInfo player)
	{
		Info = player;
	}
}
