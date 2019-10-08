using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetRadius : TargetType
{
	[Input] public float Radius;
	[Input] public CastInfo CastInfo;

	public override List<Entity> GetEntities()
	{
		var castInfo = GetInputValue("CastInfo", this.CastInfo);

		var entities = new List<Entity>();

		var colliders = Physics.OverlapSphere(castInfo.ToPosition, Radius);

		for(var i = 0; i < colliders.Length; i++)
		{
			var entity = colliders[i].GetComponent<Entity>();

			if (entity == null) continue;

			entities.Add(entity);
		}

		return entities;
	}
}
