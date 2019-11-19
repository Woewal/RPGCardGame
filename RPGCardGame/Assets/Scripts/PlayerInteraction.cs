using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	[SerializeField] float maxRange;
	[SerializeField] Transform pickupHolder;
	[SerializeField] PlayerCharacter playerCharacter;
	[SerializeField] float force;
	[SerializeField] LineRenderer lineRenderer;
	Rigidbody currentPickup;
	Cursor cursor;
	bool isAiming;

	void OnTriggerEnter(Collider other)
	{
		if (currentPickup != null) return;

		var pickup = other.GetComponent<Pickup>();

		if (pickup == null) return;

		Pickup(pickup.PickupPrefab);
		Destroy(pickup.gameObject);
	}

	void Update()
	{
		if (!isAiming) return;

		lineRenderer.SetPosition(0, pickupHolder.transform.position);
		lineRenderer.SetPosition(1, (Vector3)playerCharacter.Info.Cursor.GetWorldPosition());
	}

	void Pickup(Rigidbody pickupPrefab)
	{
		var rigidbody = Instantiate(pickupPrefab, pickupHolder);
		rigidbody.transform.localPosition = Vector3.zero;
		rigidbody.isKinematic = true;
		currentPickup = rigidbody;
		playerCharacter.Info.Input.OnPressButton += StartAim;
		playerCharacter.Info.Input.OnReleaseButton += StopAim;
		playerCharacter.Info.Input.OnReleaseButton += Throw;
		playerCharacter.Info.Input.OnReleaseButton += () =>
		{
			playerCharacter.Info.Input.OnPressButton -= StartAim;
		};
	}

	void StartAim()
	{
		isAiming = true;
		lineRenderer.enabled = true;
	}

	void StopAim()
	{
		isAiming = false;
		lineRenderer.enabled = false;
	}

	void Throw()
	{
		if (cursor == null) cursor = playerCharacter.Info.Cursor;
		var cursorPosition = cursor.GetWorldPosition();
		if (cursorPosition == null) return;

		var relativeDirection = (Vector3)cursorPosition - transform.position;
		currentPickup.transform.SetParent(null);
		currentPickup.isKinematic = false;
		currentPickup.AddForce(relativeDirection.normalized * force,  ForceMode.VelocityChange);
		playerCharacter.Info.Input.OnReleaseButton -= Throw;
		currentPickup = null;
	}
}
