using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClientInput : MonoBehaviour
{

	public void Press()
	{
		Player.Instance.GetComponent<PlayerInput>().CmdPressButton();
	}

	public void Release()
	{
		Player.Instance.GetComponent<PlayerInput>().CmdReleaseButton();
	}

	public void Calibrate()
	{
		Player.Instance.GetComponent<PointerInput>().Calibrate();
	}
}
