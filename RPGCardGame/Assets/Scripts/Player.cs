﻿using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
	public static Player Instance;

	[SyncVar]
	public int PlayerNumber;

	public System.Action OnReady;

	public override void OnStartAuthority()
	{
		base.OnStartAuthority();

		Instance = this;

		CmdRegisterPlayer();
	}

	[Command]
	void CmdRegisterPlayer()
	{
		PlayerManager.Instance.AddPlayer(this);
	}

	[ClientRpc]
	public void RpcSetPlayerReady(int playerNumber)
	{
		OnReady?.Invoke();
		if (!hasAuthority) return;
		Debug.Log(playerNumber);
		ClientPlayerManager.Instance.Initiate(playerNumber);
	}

	[Command]
	public void CmdCastSpell(int spellID)
	{
		//var position = CursorManager.Instance.GetPointPosition(PlayerNumber);

		//if (position == null) return;

		//var castInfo = new CastInfo()
		//{
		//	FromPosition = Vector3.zero,
		//	ToPosition = (Vector3)position,
		//	Caster = null
		//};

		//SpellCaster.Instance.Cast(spellID, castInfo);
	}
}
