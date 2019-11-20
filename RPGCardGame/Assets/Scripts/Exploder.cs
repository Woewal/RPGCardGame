using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
	[SerializeField] float radius;
	[SerializeField] float force;
	const float Damage = 10;
	[SerializeField] float damageMultiplier = 1;
	[SerializeField] GameObject explosionEffect;

    public void Explode()
	{
		var colliders = Physics.OverlapSphere(transform.position, radius);

		for (var i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject == gameObject) continue; 

			var entity = colliders[i].GetComponent<Entity>();

			if (entity == null || entity.Rigidbody == null) continue;

			if(entity.PlayerCharacter != null)
			{
				entity.PlayerCharacter.Movement.RemoveControl();
			}

			var health = entity.Health;

			if(health != null)
			{
				health.ChangeHealth(-(entity.transform.position - transform.position).magnitude * Damage); 
			}

			CardGame.Physics.Push(entity.Rigidbody, force, transform.position, radius);
		}

		var explosion = Instantiate(explosionEffect);
		explosion.transform.position = transform.position;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, radius);	
	}
}
