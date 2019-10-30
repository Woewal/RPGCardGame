using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
	public static CardManager Instance;
	[SerializeField] Energy energy;

	void Start()
	{
		Instance = this;
	}

	public bool PlayCard(int cardIndex)
	{
		if (!energy.HasFullEnergy) return false;

		Player.Instance.CmdCastSpell(cardIndex);
		energy.Consume();
		CardSpawner.Instance.SpawnRandomCard();

		return true;
	}
}