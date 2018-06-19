using UnityEngine;
using System.Collections;

public class CastSpell : MonoBehaviour {

    public Spell spell;
	
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            spell.CastSpell();
        }
	}
}
