using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannon : MonoBehaviour
{
	[SerializeField] PlayerCharacter playerCharacter;
	[SerializeField] float rotationSpeed;
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] GameObject muzzleFlashPrefab;
	[SerializeField] Transform cannonEndTransform;
	[SerializeField] float reloadSpeed;

	float timeSinceLastShot;
	bool isAiming;
	Cursor cursor;

	void Start()
	{
		playerCharacter.Info.Input.OnPressButton += () =>
		{
			isAiming = true;
		};
		playerCharacter.Info.Input.OnReleaseButton += () =>
		{
			isAiming = false;
			if(timeSinceLastShot > reloadSpeed)
				Shoot();
		};
	}

	void Update()
	{
		timeSinceLastShot += Time.deltaTime;

		if (!isAiming) return;

		if (cursor == null)
			cursor = playerCharacter.Info.Cursor;

		var targetPosition = (Vector3)cursor.GetWorldPosition();
		if (targetPosition == null) return;
		var magnitude = (transform.position - targetPosition).magnitude;

		var newRotation = Vector3.RotateTowards(transform.forward, targetPosition - transform.position, rotationSpeed * Time.deltaTime, 0.0f);
		transform.rotation = Quaternion.LookRotation(new Vector3(newRotation.x, 0, newRotation.z));
	}

	void Shoot()
	{
		var bullet = Instantiate(projectilePrefab);
		bullet.transform.position = cannonEndTransform.transform.position;
		bullet.transform.rotation = cannonEndTransform.transform.rotation;
		var muzzleFlash = Instantiate(muzzleFlashPrefab);
		muzzleFlash.transform.position = cannonEndTransform.transform.position;
		muzzleFlash.transform.rotation = cannonEndTransform.transform.rotation;
		timeSinceLastShot = 0;
	}
}
