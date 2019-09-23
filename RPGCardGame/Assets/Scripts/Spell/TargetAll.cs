using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using XNode;

public class TargetAll : TargetType {

	public override List<Entity> GetEntities()
	{
		return FindObjectsOfType<Entity>().ToList();

	}
}