using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : NetworkBehaviour
{

	[Command]
	void CmdProcessInput(int horizontal, int vertical)
	{
		CursorManager.Instance.Test(horizontal, vertical);
	}

	void Start()
	{
		if (!hasAuthority) return;
		StartCoroutine(StartUpdating());
	}

	void Update()
	{
		if (!hasAuthority) return;

		if (Input.GetKeyDown(KeyCode.W))
			transform.Translate(Vector3.forward);

		if (Input.GetKeyDown(KeyCode.A))
			transform.Translate(Vector3.left);

		if (Input.GetKeyDown(KeyCode.D))
			transform.Translate(Vector3.right);

		if (Input.GetKeyDown(KeyCode.S))
			transform.Translate(Vector3.back);
	}

	IEnumerator StartUpdating()
	{
		while (true)
		{
			CmdProcessInput((int)transform.position.x, (int)transform.position.z);
			yield return new WaitForSeconds(1);

		}
	}
}
