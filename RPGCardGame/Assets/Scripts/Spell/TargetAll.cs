using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using XNode;

public class TargetAll : TargetType {
	public override object GetValue(NodePort port)
	{
		if(port.fieldName == "Targets")
		{
			var entities = FindObjectsOfType<Entity>().ToList();
			Debug.Log(entities.Count);
			return entities;
		}

		return null;
	}
}