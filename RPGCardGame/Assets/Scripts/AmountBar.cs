using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountBar : MonoBehaviour
{
	[SerializeField] Image bar;

	void Awake()
	{
		bar.fillAmount = 1;
	}

	public void UpdateBar(float percent)
	{
		Debug.Log(percent);
		bar.fillAmount = percent;
	}
}
