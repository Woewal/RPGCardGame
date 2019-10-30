using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
	[Range(0,1)]
	[SerializeField] float rechargeRate;
	float currentEnergy;
	public bool HasFullEnergy
	{
		get
		{
			return currentEnergy == 1;
		}
	}
	[SerializeField] AmountBar energyBar;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E)) Consume();

		currentEnergy += rechargeRate * Time.deltaTime;

		if (currentEnergy > 1)
			currentEnergy = 1;

		energyBar.UpdateBar(currentEnergy);
	}

	public void Consume()
	{
		currentEnergy = 0;
		energyBar.UpdateBar(currentEnergy);
	}
}
