using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
	public static CursorManager Instance;

	Camera camera;
	Plane plane = new Plane(new Vector3(0, 1, 0), 0);
	public Cursor CursorPrefab;
	public RectTransform CursorParent;
	public Dictionary<int, Cursor> Cursors = new Dictionary<int, Cursor>();

	void Awake()
	{
		Instance = this;	
	}

	public void RegisterPlayer(int id)
	{
		var cursor = Instantiate(CursorPrefab, CursorParent);
		Cursors.Add(id, cursor);
	}

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
			Cast();
	}

	public void MoveCursor(int id, float horizontal, float vertical)
	{
		var cursor = Cursors[id];
		cursor.TargetPosition = new Vector3(Screen.width / 2 + horizontal, Screen.height / 2 + vertical);
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
