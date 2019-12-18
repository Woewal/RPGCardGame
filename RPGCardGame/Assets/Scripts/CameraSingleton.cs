﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSingleton : MonoBehaviour
{
	public static CameraSingleton Instance;

	void Awake()
	{
		Instance = this;	
	}
}