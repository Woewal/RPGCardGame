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
			var rigidbody = colliders[i].GetComponent<Rigidbody>();

			if (rigidbody == null) continue;

			CardGame.Physics.Push(rigidbody, force, transform.position, radius);
		}

		var explosion = Instantiate(explosionEffect);
		explosion.transform.position = transform.position;
	}
}
