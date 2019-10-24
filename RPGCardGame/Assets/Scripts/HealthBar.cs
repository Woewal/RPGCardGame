using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] Image healthBarImage;

	void Awake()
	{
		healthBarImage.fillAmount = 1;
	}

	public void UpdateHealthBar(float percent)
	{
		healthBarImage.fillAmount = percent;
	}
}
