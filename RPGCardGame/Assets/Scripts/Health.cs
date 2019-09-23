using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	public int MaxHealth;
	[HideInInspector] public int CurrentHealth { get; private set; }
	UnityEvent OnDeath = new UnityEvent();

	private void Start()
	{
		CurrentHealth = MaxHealth;
		OnDeath.AddListener(() =>
		{
			Destroy(gameObject);
		});
	}

	public void ChangeHealth(int amount)
	{
		Debug.Log("Changing health");

		CurrentHealth += amount;

		if (CurrentHealth > MaxHealth)
			CurrentHealth = MaxHealth;
		else if (CurrentHealth < 0)
			CurrentHealth = 0;
			OnDeath?.Invoke();

		Debug.Log(string.Format("Current health: {0}", CurrentHealth));
	}
}
