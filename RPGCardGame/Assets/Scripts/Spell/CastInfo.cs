﻿using UnityEngine;
using System.Collections;

public class CastInfo
{
	public Vector3 FromPosition;
	public Vector3 ToPosition;
	public Vector3 DirectionVector
	{
		get
		{
			return (ToPosition - FromPosition).normalized;
		}
	}
	public Character Caster;
}
