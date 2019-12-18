using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
	public Vector3 TargetPosition;
	public float Speed;

	Camera camera;
	Plane plane = new Plane(new Vector3(0, 1, 0), 0);

	public System.Action<Vector3> OnCast;

	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * Speed);
	}

	public Vector3? GetWorldPosition()
	{
		var screenPosition = transform.position;
		Ray ray = CameraSingleton.Instance.GetComponent<Camera>().ScreenPointToRay(screenPosition);
		float enter = 0;

		if (plane.Raycast(ray, out enter))
		{
			Vector3 hitPoint = ray.GetPoint(enter);
			return hitPoint;
		}

		return null;
	}
}
