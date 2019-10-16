using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : TargetAction
{
	[Input] public int Radius;
	[Input] public int Amount;
	[Input] public CastInfo CastInfo;

	public override void ExecuteAction()
	{
		var targets = GetInputValue("Targets", this.Targets);

		Debug.Log("Pulling: " + targets.Count + " entities");

		for (int i = 0; i < targets.Count; i++)
		{
			var target = targets[i];

			var rigidbody = target.Rigidbody;

			if (rigidbody == null) continue;

			var amount = GetInputValue("Amount", this.Amount);
			var castInfo = GetInputValue("CastInfo", this.CastInfo);
			var radius = GetInputValue("Radius", this.Radius);

			CardGame.Physics.Pull(rigidbody, amount, castInfo.ToPosition, radius);
		}

		Finish();
	}
}
