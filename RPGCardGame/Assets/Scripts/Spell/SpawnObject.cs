using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class SpawnObject : Action
{
    [Input] public GameObject ObjectPrefab;
	[Input] public CastInfo CastInfo;

	public override void ExecuteAction()
	{
		var effect = Instantiate(GetInputValue("EffectPrefab", this.ObjectPrefab));
		effect.transform.position = GetInputValue("CastInfo", this.CastInfo).ToPosition;

		Finish();
	}
}