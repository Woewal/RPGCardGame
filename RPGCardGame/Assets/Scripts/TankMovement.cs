using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
	[SerializeField] PlayerCharacter playerCharacter;
	[SerializeField] float accelerationSpeed;
	[SerializeField] float deaccelerationSpeed;
	[SerializeField] float rotationSpeed;
	[SerializeField] float maxSpeed;
	[SerializeField] CharacterController characterController;
	[SerializeField] float range;

	float velocity; 
	Cursor cursor;
	bool isAiming;

	void Start()
	{
		playerCharacter.Info.Input.OnPressButton += () =>
		{
			isAiming = true;
		};
		playerCharacter.Info.Input.OnReleaseButton += () =>
		{
			isAiming = false;
		};
	}

	void Update()
	{
		velocity -= Time.deltaTime * deaccelerationSpeed;

		if (velocity < 0) velocity = 0;

		characterController.Move(transform.forward * Time.deltaTime * velocity);

		if (isAiming) return;

		if (cursor == null)
			cursor = playerCharacter.Info.Cursor;

		var targetPosition = (Vector3)cursor.GetWorldPosition();
		if (targetPosition == null) return;
		var magnitude = (transform.position - targetPosition).magnitude;

		velocity += Time.deltaTime * accelerationSpeed * Mathf.Lerp(0, 1, range / magnitude);

		if (velocity > maxSpeed) velocity = maxSpeed;
		
		var newRotation = Vector3.RotateTowards(transform.forward, targetPosition - transform.position, rotationSpeed * Time.deltaTime, 0.0f);
		transform.rotation = Quaternion.LookRotation(new Vector3(newRotation.x, 0, newRotation.z));

		Debug.Log(velocity);
	}
}
