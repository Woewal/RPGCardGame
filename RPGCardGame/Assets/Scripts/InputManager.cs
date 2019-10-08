using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance;

	void Start()
	{
		Instance = this;	
	}

	public void Calibrate()
	{
		Player.Instance.GetComponent<GyroscopeInputManager>().CalibratedRotation = GyroToUnity(Input.gyro.attitude);
	}

	Quaternion GyroToUnity(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}
}
