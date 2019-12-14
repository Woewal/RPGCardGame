using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour, IDamagable
{
	[SerializeField] Health health; 

	public void Damage(int amount)
	{
		health.ChangeHealth(-amount);
	}
}
