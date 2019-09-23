using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	Camera camera;
	Plane plane = new Plane(new Vector3(0, 1, 0), 0);

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
			Cast();
	}

	public Vector3? Cast()
	{
		var screenPosition = Input.mousePosition;
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		float enter = 0;

		if(plane.Raycast(ray, out enter))
		{
			Vector3 hitPoint = ray.GetPoint(enter);
			return hitPoint;
		}

		return null;
	}
}
