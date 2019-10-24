using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrater : MonoBehaviour
{
	public void Calibrate()
	{
		Player.Instance.GetComponent<PointerInput>().Calibrate();
	}
}
