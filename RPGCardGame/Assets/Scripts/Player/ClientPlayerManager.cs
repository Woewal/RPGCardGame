using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientPlayerManager : MonoBehaviour
{
	[SerializeField] Image backgroundImage;
	[SerializeField] PlayerColors playerColors;

	public static ClientPlayerManager Instance;

	void Awake()
	{
		Instance = this;	
	}

	public void Initiate(int id)
	{
		backgroundImage.color = playerColors.Colors[id - 1];
	}
}
