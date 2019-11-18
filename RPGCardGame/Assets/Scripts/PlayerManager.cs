using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager Instance;

	public List<PlayerInfo> Players = new List<PlayerInfo>();
	public Action<PlayerInfo> OnPlayerAdded;

	void Awake()
	{
		Instance = this;
	}

	public void AddPlayer(Player player)
	{
		var playerInfo = new PlayerInfo()
		{
			Player = player,
			Input = player.GetComponent<PlayerInput>(),
			Number = Players.Count + 1
		};

		player.RpcSetPlayerReady(playerInfo.Number);
		Players.Add(playerInfo);

		OnPlayerAdded?.Invoke(playerInfo);
	}
}

public class PlayerInfo
{
	public Player Player;
	public PlayerInput Input;
	public int Number;
	public Cursor Cursor;
}
