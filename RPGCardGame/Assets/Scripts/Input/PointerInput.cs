using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerInput : MonoBehaviour
{
	public Action<Vector2> OnUpdate;
	float sensitivity = 40;

	public Vector2 Offset;

	private void Start()
	{
		if (SystemInfo.supportsGyroscope)
		{
			if (!Input.gyro.enabled)
				Input.gyro.enabled = true;

			Calibrate();
		}
	}

	public void Calibrate()
	{
		Offset = Vector2.zero;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.gyro.enabled)
		{
			Offset += new Vector2(-Input.gyro.rotationRate.z * sensitivity, Input.gyro.rotationRate.x * sensitivity);

			OnUpdate?.Invoke(Offset);
		}
		else
		{
			var Offset = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);

			OnUpdate?.Invoke(Offset);
		}
	}
}
