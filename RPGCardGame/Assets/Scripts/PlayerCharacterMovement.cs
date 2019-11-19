using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
	[SerializeField] float maxSpeed;
	[SerializeField] float maxRange;
	[SerializeField] GameObject rotationIndicator;
	[SerializeField] float slowDownThreshold = 0.5f;
	Vector3 targetPosition = Vector3.zero;
	Rigidbody rgbd;
	bool canControl = true;
	bool isAiming = false;

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
		player.Input.OnPressButton = () =>
		{
			isAiming = true;
		};
		player.Input.OnReleaseButton = () =>
		{
			isAiming = false;
		};

	}

	void Update()
	{
		if (targetPosition == Vector3.zero || !canControl || isAiming) return;
		var relativeVector = targetPosition - transform.position;
		rotationIndicator.transform.LookAt(targetPosition, Vector3.up);
		var distance = Mathf.Clamp(relativeVector.magnitude, 0, maxRange);
		var movementSpeed = Mathf.Lerp(0, maxSpeed, distance / maxRange);
		rgbd.velocity = relativeVector.normalized * movementSpeed;
	}
	
	public void RemoveControl()
	{
		StopAllCoroutines();
		StartCoroutine(WaitForSlowDown());
	}

	IEnumerator WaitForSlowDown()
	{
		canControl = false;

		while (rgbd.velocity.magnitude > slowDownThreshold)
		{
			yield return null;
		}

		canControl = true;
	}
}
