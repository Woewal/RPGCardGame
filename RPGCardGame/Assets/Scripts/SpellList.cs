using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellList", menuName = "Spells/SpellList")]
public class SpellList : ScriptableObject
{
	public List<Spell> Spells;
}
