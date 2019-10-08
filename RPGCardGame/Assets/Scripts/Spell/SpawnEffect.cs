using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class SpawnEffect : Action
{
    [Input] public GameObject EffectPrefab;
	[Input] public CastInfo CastInfo;

	public override void ExecuteAction()
	{
		var effect = Instantiate(GetInputValue("EffectPrefab", this.EffectPrefab));
		effect.transform.position = GetInputValue("CastInfo", this.CastInfo).ToPosition;

		Finish();
	}
}
