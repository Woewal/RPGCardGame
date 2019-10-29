﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	public int MaxHealth;
	[HideInInspector] public float CurrentHealth { get; private set; }
	[SerializeField] AmountBar healthBar;
	public UnityEvent OnDeath = new UnityEvent();

	private void Start()
	{
		CurrentHealth = MaxHealth;
		OnDeath.AddListener(() =>
		{
			Destroy(gameObject);
		});
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			CurrentHealth = MaxHealth;
			ChangeHealth(0);
		}
	}

	public void ChangeHealth(float amount)
	{
		CurrentHealth += amount;

		if (CurrentHealth > MaxHealth)
			CurrentHealth = MaxHealth;
		else if (CurrentHealth < 0)
		{
			CurrentHealth = 0;
			OnDeath?.Invoke();
		}

		if (healthBar != null)
			healthBar.UpdateBar((float)CurrentHealth / (float)MaxHealth);
	}

	void OnCollisionEnter(Collision collision)
	{
		ChangeHealth(-collision.relativeVelocity.magnitude * 2);
	}
}
