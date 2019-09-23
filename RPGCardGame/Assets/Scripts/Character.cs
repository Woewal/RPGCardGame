using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamType { Friendly, Enemy }

public class Character : MonoBehaviour
{
	public TeamType Team;

	public Spell Spell;

	public InputManager InputManager;

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(InputManager == null)
			CastSpell();
		}
	}

	public void CastSpell()
	{
		var targetPosition = InputManager.Cast();

		if (targetPosition == null) return;

		var castInfo = new CastInfo
		{
			Caster = this,
			FromPosition = transform.position,
			ToPosition = (Vector3)targetPosition,
		};

		var spellNode = (SpellNode)Spell.nodes[0];
		spellNode.CastInfo = castInfo;
		spellNode.GoNext();
		
	}
}
