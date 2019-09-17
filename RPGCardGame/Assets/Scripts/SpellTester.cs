using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTester : MonoBehaviour
{
	[SerializeField] Spell spell;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.E))
			(spell.nodes[0] as SpellNode).GoNext();
    }
}
