using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
	List<Rigidbody> closeObjects = new List<Rigidbody>();
	[SerializeField] float damageMultiplier;
	[SerializeField] float strength;

	void OnTriggerEnter(Collider other)
	{
		var rigidbody = other.GetComponent<Rigidbody>();

		if (rigidbody == null) return;

		closeObjects.Add(rigidbody);
	}

	void OnTriggerExit(Collider other)
	{
		var rigidbody = other.GetComponent<Rigidbody>();

		if (rigidbody == null) return;

		if (!closeObjects.Contains(rigidbody)) return;

		closeObjects.Remove(rigidbody);
	}

	void Update()
	{
		for (int i = 0; i < closeObjects.Count; i++)
		{
			var rigidbody = closeObjects[i];

			if (rigidbody == null) continue;

			rigidbody.AddForce((transform.position - rigidbody.transform.position) * strength * Time.smoothDeltaTime);
		}
	}

}
