using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroscopeInputManager : NetworkBehaviour
{
	public Slider slider;

	Quaternion originalRotation = Quaternion.identity;

	int id;

	double sensitivity = 40;

	void Start()
	{
		if (!hasAuthority) return;

		id = (int)GetComponent<NetworkIdentity>().netId;
		CmdRegisterPlayer();
		StartCoroutine(UpdateCursorPositionCoroutine());
	}

	[Command]
	void CmdRegisterPlayer()
	{
		Debug.Log("Registered player");
		CursorManager.Instance.RegisterPlayer(id);
	}

	IEnumerator UpdateCursorPositionCoroutine()
	{
		while(true)
		{
			//sensitivity = slider.value;

			if (Input.touchCount > 0)
				originalRotation = GyroToUnity(Input.gyro.attitude);

			if (originalRotation == Quaternion.identity && !SystemInfo.supportsGyroscope)
			{
				yield return null;
			}

			if (SystemInfo.supportsGyroscope)
			{
				Input.gyro.enabled = true;
				var rotation = GyroToUnity(Input.gyro.attitude);
				Quaternion relative = Quaternion.Inverse(rotation) * originalRotation;
				CmdChangeCursorPosition(GetRelativeAngle(relative.eulerAngles.z), GetRelativeAngle(relative.eulerAngles.x));
			}
			else
			{
				CmdChangeCursorPosition(Input.mousePosition.x, Input.mousePosition.y);
			}

			yield return new WaitForSeconds(.005f);
		}
	}

	private static Quaternion GyroToUnity(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}

	public void ChangeSensitivity(double amount)
	{
		sensitivity = amount;
	}

	[Command]
	public void CmdChangeCursorPosition(float horizontal, float vertical)
	{
		var horizontalReal = horizontal * (float)sensitivity;
		var verticalReal = vertical * (float)sensitivity;

		CursorManager.Instance.MoveCursor(id, horizontalReal, verticalReal);
	}

	float GetRelativeAngle(float relativeAngle)
	{
		if(relativeAngle > 180)
		{
			return relativeAngle - 360;
		}
		else
		{
			return relativeAngle;
		}
	}
}
