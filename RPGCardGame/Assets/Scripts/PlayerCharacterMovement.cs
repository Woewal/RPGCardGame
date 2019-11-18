using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
	[SerializeField] float maxSpeed;
	[SerializeField] float maxRange;
	[SerializeField] GameObject rotationIndicator;
	Vector3 targetPosition = Vector3.zero;
	Rigidbody rgbd;

	void Start()
	{
		rgbd = GetComponent<Rigidbody>();	
	}

	public void Initiate(PlayerInfo player)
	{
		player.Cursor.OnCast = null;
		player.Input.OnGyroscopeUpdate += (cursorPosition) =>
		{
			var position =  player.Cursor.GetWorldPosition();
			if (position == null) return;
			targetPosition = (Vector3)position;
		};

	}

	void Update()
	{
		if (targetPosition == Vector3.zero) return;
		var relativeVector = targetPosition - transform.position;
		rotationIndicator.transform.LookAt(targetPosition, Vector3.up);
		var distance = Mathf.Clamp(relativeVector.magnitude, 0, maxRange);
		var movementSpeed = Mathf.Lerp(0, maxSpeed, distance / maxRange);
		rgbd.velocity = relativeVector.normalized * movementSpeed;
	}
}
