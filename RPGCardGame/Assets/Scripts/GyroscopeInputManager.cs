using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroscopeInputManager : MonoBehaviour
{
	public Text Text;
	public GameObject RotationObject;
	public RectTransform Cursor;
	public Slider slider;

	Quaternion originalRotation = Quaternion.identity;

	double sensitivity = 2;

	void Update()
	{
		Text.text = "";
		sensitivity = slider.value;

		if (Input.touchCount > 0)
			originalRotation = GyroToUnity(Input.gyro.attitude);

		if (originalRotation == Quaternion.identity && !SystemInfo.supportsGyroscope)
		{
			Text.text = "Set rotation";
			return;
		}

		if (SystemInfo.supportsGyroscope)
		{
			Input.gyro.enabled = true;
			var rotation = GyroToUnity(Input.gyro.attitude);
			RotationObject.transform.rotation = rotation;
			Quaternion relative = Quaternion.Inverse(rotation) * originalRotation;
			Text.text += rotation.ToString();
			Text.text += " - ";
			Text.text += relative.eulerAngles.ToString();
			Text.text += " - ";
			Text.text += string.Format("Horizontal: {0}, Vertical: {1}", GetRelativeAngle(relative.eulerAngles.z), GetRelativeAngle(relative.eulerAngles.x));
			ChangeCursorPosition(GetRelativeAngle(relative.eulerAngles.z), GetRelativeAngle(relative.eulerAngles.x));
		}
		else
		{
			Text.text = "No gyro";
			ChangeCursorPosition(Input.mousePosition.x, Input.mousePosition.y);
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

	public void ChangeCursorPosition(float horizontal, float vertical)
	{
		Cursor.transform.position = new Vector3(Screen.width / 2 + horizontal * (float)sensitivity, Screen.height / 2 + vertical * (float)sensitivity);
		Debug.Log(Cursor.transform.position);
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
