using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
	public static Player Instance;

	public override void OnStartAuthority()
	{
		base.OnStartAuthority();

		Debug.Log("Player started");

		Instance = this;
	}

	void Start()
	{
		if (!hasAuthority) return;

		Instance = this;
	}

	public void CastSpell(int spellIndex)
	{
		GetComponent<GyroscopeInputManager>().CmdCastSpell(spellIndex);
	}
}
