using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class TargetType : Node {

	public enum Type { Friendly, Enemy, All }
	
	[Output] public List<Entity> Targets;
	[Input] public Type Limit;
	public override object GetValue(NodePort port)
	{
		return base.GetValue(port);
	}
}