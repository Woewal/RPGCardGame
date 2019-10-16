using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager Instance;

	public int Players = 0;

	void Start()
	{
		Instance = this;
	}

	public void AddPlayer()
	{
		Players += 1;
	}
}
