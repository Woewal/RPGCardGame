using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
	[SerializeField] float radius;
	[SerializeField] float force;
	[SerializeField] GameObject explosionEffect;

    public void Explode()
	{
		var colliders = Physics.OverlapSphere(transform.position, radius);

		for (var i = 0; i < colliders.Length; i++)
		{
			var entity = colliders[i].GetComponent<Entity>();

			if (entity == null || entity.Rigidbody == null) continue;

			if(entity.PlayerCharacter != null)
			{
				entity.PlayerCharacter.Movement.RemoveControl();
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
