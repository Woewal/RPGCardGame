using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	public Health Health;
	public Character Character;

	void Start()
	{
		Health = GetComponent<Health>();
		Character = GetComponent<Character>();
	}
}
