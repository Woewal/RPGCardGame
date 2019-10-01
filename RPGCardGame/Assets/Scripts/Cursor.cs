using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
	public Vector3 TargetPosition;
	public float Speed;

	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * Speed);
	}
}
