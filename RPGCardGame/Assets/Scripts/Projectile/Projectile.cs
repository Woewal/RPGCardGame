using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float time;

	float timeAlive;

	void Update()
	{
		if(timeAlive > time)
		{
			Destroy(gameObject);
			return;
		}

		timeAlive += Time.deltaTime;

		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision collision)
	{
		var damagable = collision.collider.GetComponent<IDamagable>();

		if(damagable == null)
		{
			var direction = Vector3.Reflect(new Vector3(transform.forward.x, 0, transform.forward.z), new Vector3(collision.contacts[0].normal.x, 0, collision.contacts[0].normal.z));
			transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
		}
		else
		{
			damagable.Damage(10);
			Destroy(gameObject);
		}

	}
}
