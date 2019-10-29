using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
	int HealthPoints = 5;
	[SerializeField] TextMeshPro text;

	private void Start()
	{
		text.text = HealthPoints.ToString();
	}

	public void Score()
	{
		if (HealthPoints == 0)
			return;

		HealthPoints -= 1;

		text.text = HealthPoints.ToString();
	}
}
