using UnityEngine;
using System.Collections;
using XNode;
using System.Collections.Generic;

public abstract class TargetAction : Action
{
	[Input] public List<Entity> Targets;

	public override object GetValue(NodePort port)
	{
		if(port.fieldName == "Targets")
		{
			var test = GetInputValue("Targets", this.Targets);
			return  test;
		}

		return base.GetValue(port);
	}
}
