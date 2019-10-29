using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	Vector3 originalPosition;

	void Start()
	{
		originalPosition = transform.position;	
	}

	void OnCollisionEnter(Collision collision)
	{
		var goal = collision.gameObject.GetComponent<Goal>();

		if (goal == null) return;

		goal.Score();

		transform.position = originalPosition;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}
