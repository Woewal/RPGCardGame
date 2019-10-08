using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamType { Friendly, Enemy }

public class Character : MonoBehaviour
{
	public TeamType Team;

	public Spell Spell;
}
