using UnityEngine;
using System.Collections;
using Mirror;
using System;

public class PlayerInput : NetworkBehaviour
{
	public Action<Vector2> OnGyroscopeUpdate;
	public System.Action OnPressButton;
	public System.Action OnReleaseButton;

	public override void OnStartAuthority()
	{
		base.OnStartAuthority();

		var pointerInput = GetComponent<PointerInput>();

		pointerInput.OnUpdate += CmdUpdateGyroscope;
	}

	[Command]
	public void CmdUpdateGyroscope(Vector2 inputVector)
	{
		OnGyroscopeUpdate?.Invoke(inputVector);
	}

	[Command]
	public void CmdPressButton()
	{
		OnPressButton?.Invoke();
	}

	[Command]
	public void CmdReleaseButton()
	{
		OnReleaseButton?.Invoke();
	}


}
