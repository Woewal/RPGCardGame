using UnityEngine;
using System.Collections;

public class ClientInput : MonoBehaviour
{
	public void Click()
	{
		Player.Instance.GetComponent<PlayerInput>().CmdPressButton();
	}

	public void Calibrate()
	{
		Player.Instance.GetComponent<PointerInput>().Calibrate();
	}
}
