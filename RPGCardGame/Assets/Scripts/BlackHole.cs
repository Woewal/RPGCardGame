using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlackHole : MonoBehaviour
{
	[SerializeField] float radius;
	[SerializeField] float force;
	[SerializeField] List<Rigidbody> rigidbodies;

	void Update()
	{
		//for (int i = 0; i < length; i++)
		//{

		//}	
	}

	void OnTriggerEnter(Collider other)
	{
		var rigidbody = other.GetComponent<Rigidbody>();

		if (rigidbody == null)
			return;

		rigidbodies.Add(rigidbody);
	}

	void OnTriggerExit(Collider other)
	{
		var rigidbody = other.GetComponent<Rigidbody>();

		if (rigidbody == null)
			return;

		rigidbodies.Remove(rigidbody);
	}
}
