using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTester : MonoBehaviour
{
	[SerializeField] int spellIndex;

	Plane plane = new Plane(new Vector3(0, 1, 0), 0);


	private void Start()
	{
		if (NetworkServer.connections.Count != 0)
			enabled = false;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var position = Cast();

			if (position == null) return;

			var castInfo = new CastInfo()
			{
				Caster = null,
				FromPosition = Vector3.zero,
				ToPosition = (Vector3)position
			};

			GetComponent<SpellCaster>().Cast(spellIndex, castInfo);
		}
	}

	public Vector3? Cast()
	{
		var screenPosition = Input.mousePosition;
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		float enter = 0;

		if (plane.Raycast(ray, out enter))
		{
			Vector3 hitPoint = ray.GetPoint(enter);
			return hitPoint;
		}

		return null;
	}
}
