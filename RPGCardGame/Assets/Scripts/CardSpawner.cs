using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
	public static CardSpawner Instance;

	[SerializeField] SpellList spells;
	[SerializeField] Card cardPrefab;
	[SerializeField] Transform cardParent;

	[SerializeField] int startingCardsAmount;
	[SerializeField] float spawnInterval;

	[SerializeField] int minimumVerticalSpeed;
	[SerializeField] int maximumVerticalSpeed;
	[SerializeField] int horizontalSpeed;

	public void Start()
	{
		Instance = this;
		StartCoroutine(GiveStartingCards());
	}

	IEnumerator GiveStartingCards()
	{
		for (int i = 0; i < startingCardsAmount; i++)
		{
			SpawnRandomCard();
			yield return new WaitForSeconds(spawnInterval);
		}
	}

	public Card SpawnRandomCard()
	{
		int randomSpellIndex = Random.Range(0, spells.Spells.Count);
		return SpawnCard(randomSpellIndex);

	}

	public Card SpawnCard(int id)
	{
		var card = Instantiate(cardPrefab, cardParent);

		var rectTransform = card.GetComponent<RectTransform>();
		rectTransform.transform.position = new Vector2(Screen.width / 2, - rectTransform.rect.height / 2);
		card.Initiate(spells.Spells[id], id);

		var cardMovement = card.GetComponent<CardMovement>();
		var rigidbody = card.GetComponent<Rigidbody2D>();
		cardMovement.velocity = new Vector3(Random.Range(-horizontalSpeed, horizontalSpeed), Random.Range(minimumVerticalSpeed, maximumVerticalSpeed));
		return card;
	}


}
