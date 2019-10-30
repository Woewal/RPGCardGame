using UnityEngine;
using System.Collections;
using TMPro;

public class Card : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI title;
	Spell spell;
	int spellID;

	public bool Cast()
	{
		if (Player.Instance == null) return false;
		var casted = CardManager.Instance.PlayCard(spellID);
		return casted;
	}

	public void Initiate(Spell spell, int index)
	{
		spellID = index;
		title.text = spell.name;
	}
}
