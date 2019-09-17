using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class SpellNode : Node {

	[Input] public int Cost;
	[Input] public string Description;
	[Input] public List<Character> Targets;
}