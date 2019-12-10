using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] float speed;

	void Update()
	{
		transform.Translate(transform.forward * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);	
	}
}
