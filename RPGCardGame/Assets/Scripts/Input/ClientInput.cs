using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClientInput : MonoBehaviour
{

	public void Press()
	{
		Debug.Log("press");
		Player.Instance.GetComponent<PlayerInput>().CmdPressButton();
	}

	public void Release()
	{
		Debug.Log("release");
		Player.Instance.GetComponent<PlayerInput>().CmdReleaseButton();
	}

	public void Calibrate()
	{
		Player.Instance.GetComponent<PointerInput>().Calibrate();
	}
}
