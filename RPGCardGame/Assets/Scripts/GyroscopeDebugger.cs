using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeDebugger : MonoBehaviour
{
	public Quaternion CalibratedRotation = Quaternion.identity;

	public GameObject Cursor;
	public GameObject ExampleObject;

	public void Calibrate()
	{
		CalibratedRotation = Input.gyro.attitude;
	}

    // Update is called once per frame
    void Update()
    {
		Input.gyro.enabled = true;
		var rotation = GyroToUnity(Input.gyro.attitude);
		Quaternion relative = Quaternion.Inverse(rotation) * CalibratedRotation;
		Cursor.transform.position = new Vector3(GetRelativeAngle(relative.eulerAngles.z) * 40, GetRelativeAngle(relative.eulerAngles.x * 40));
		ExampleObject.transform.rotation = Input.gyro.attitude;
	}

	float GetRelativeAngle(float relativeAngle)
	{
		if (relativeAngle > 180)
		{
			return relativeAngle - 360;
		}
		else
		{
			return relativeAngle;
		}
	}

	private static Quaternion GyroToUnity(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}
}
