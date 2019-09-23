using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetRadius : TargetType
{
	[Input] public float Radius;

	public override List<Entity> GetEntities()
	{
		throw new System.NotImplementedException();
	}
}
