using UnityEngine;
using System.Collections;
using XNode;
using System.Collections.Generic;

public class TargetFilter : Node
{
	[Input] public List<Entity> Targets;
	[Input] public TeamType Filter;
	[Output] public List<Entity> FilteredTargets;

	public override object GetValue(NodePort port)
	{
		if(port.fieldName == "FilteredTargets")
			return FilterEntities();

		return null;
	}

	public List<Entity> FilterEntities()
	{
		var entities = GetInputValue("Targets", Targets);
		var filter = GetInputValue<TeamType>("Filter", Filter);

		for (int i = 0; i < entities.Count; i++)
		{
			var entity = entities[i];
			var character = entity.Character;
			if (character == null) continue;

			//TODO compare caster with filter;
			continue;
		}

		return null;
	}
}
