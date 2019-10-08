using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
	public static SpellCaster Instance = null;

	[SerializeField] SpellList availableSpells;

	private void Awake()
	{
		Instance = this;
	}

	public void Cast(int spellID, CastInfo castInfo)
	{
		var spell = availableSpells.Spells[spellID];

		var spellNode = spell.nodes[0] as SpellNode;

		spellNode.CastInfo = castInfo;

		spellNode.GoNext();

	}
}
