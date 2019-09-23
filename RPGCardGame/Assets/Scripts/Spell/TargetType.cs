using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

public abstract class TargetType : Node {
	
	[Output] public List<Entity> Targets;

	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "Targets")
		{
			return GetEntities();
		}

		return null;
	}

	public abstract List<Entity> GetEntities();
}