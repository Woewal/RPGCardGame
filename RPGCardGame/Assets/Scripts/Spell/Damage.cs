using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class Damage : TargetAction
{
	public override void ExecuteAction()
	{
		var targets = GetInputValue("Targets", this.Targets);
		Debug.Log("Deal x damage!");
		Finish();
	}
}