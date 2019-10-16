using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PointerNetworker : NetworkBehaviour
{
	int playerNumber;

	void Start()
	{
		GetComponent<PointerInput>().enabled = false;
		GetComponent<Player>().OnReady += Initiate;
	}
	
	public void Initiate()
	{
		var pointer = GetComponent<PointerInput>();

		pointer.enabled = true;

		CmdRegisterCursor();
		pointer.OnUpdate += CmdUpdatePointer;
	}

	[Command]
	void CmdRegisterCursor()
	{
		playerNumber = GetComponent<Player>().PlayerNumber;
		Debug.Log("Registered with id: " + playerNumber);
		CursorManager.Instance.RegisterPlayer(playerNumber);
	}

	[Command]
	void CmdUpdatePointer(Vector2 position)
	{
		CursorManager.Instance.MoveCursor(playerNumber, position.x, position.y);
	}


}
