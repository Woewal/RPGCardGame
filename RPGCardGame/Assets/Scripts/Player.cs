using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [Command]
	void CmdTestThing()
	{
		Debug.Log("Test");
	}

	void Update()
	{
		if (!hasAuthority) return;

		if (Input.GetKeyDown(KeyCode.E))
			CmdTestThing();
	}
}
