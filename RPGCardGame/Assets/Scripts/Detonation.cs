using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Detonation : MonoBehaviour
{
	[SerializeField] int seconds;
	[SerializeField] UnityEvent onDetonation;
	[SerializeField] TextMeshPro text;
	int timeLeft;

	void Start()
	{
		StartCoroutine(StartTimer());
	}

	IEnumerator StartTimer()
	{
		timeLeft = seconds + 1;
		while(timeLeft > 0)
		{
			timeLeft--;
			text.text = timeLeft.ToString();
			yield return new WaitForSeconds(1f);
		}

		onDetonation.Invoke();
	}
}
