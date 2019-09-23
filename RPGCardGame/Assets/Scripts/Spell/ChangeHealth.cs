﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ChangeHealth : TargetAction
{
	[Input] public int Amount;

	public override void ExecuteAction()
	{

		var targets = GetInputValue("Targets", this.Targets);

		for (int i = 0; i < targets.Count; i++)
		{
			var target = targets[i];

			var health = target.Health;

			if (health == null) continue;

			health.ChangeHealth(GetInputValue("Amount", this.Amount));
		}

		Finish();
	}
}