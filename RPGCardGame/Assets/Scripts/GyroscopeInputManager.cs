using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroscopeInputManager : NetworkBehaviour
{
	public Slider slider;

	public Quaternion CalibratedRotation = Quaternion.identity;

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

			if (CalibratedRotation == Quaternion.identity && !SystemInfo.supportsGyroscope)
			{
				yield return null;
			}

			if (SystemInfo.supportsGyroscope)
			{
				Input.gyro.enabled = true;
				var rotation = GyroToUnity(Input.gyro.attitude);
				Quaternion relative = Quaternion.Inverse(rotation) * CalibratedRotation;
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

	[Command]
	public void CmdCastSpell(int spellID)
	{
		var position = CursorManager.Instance.GetPointPosition(id);

		if (position == null) return;

		var castInfo = new CastInfo()
		{
			FromPosition = Vector3.zero,
			ToPosition = (Vector3)position,
			Caster = null
		};

		SpellCaster.Instance.Cast(spellID, castInfo);
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
