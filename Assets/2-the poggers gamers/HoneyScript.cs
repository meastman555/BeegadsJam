using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyScript : MonoBehaviour
{
    //editor specified sprites that represent the different amounts of honey
    //number of phases is also set in the editor for best generalizability and reusability
    [SerializeField] Sprite[] honeyPhases;

    //easter egg array of alt sprites
    [SerializeField] Sprite[] honeyPhasesAlt;

    //multiple of spaces needed to change honey sprite
    [SerializeField] int spacesForPhaseChange;

    private SpriteRenderer spriteRenderer;
    private int index;
    
    //starts honey at the initial sprite when game starts
    void Start() {   
        index = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = honeyPhases[index];
    }

    //for each spacebar press, check if we have to update the honey's phase and do so
    //returns true if we've reached out last phase (empty) so we can switch to new honey bottle
    public bool ProcessAction(int numSpacesPressed) {
        //uses preincrement for the index so we can do this all in one line with ternary operator
        spriteRenderer.sprite = (numSpacesPressed % spacesForPhaseChange == 0) ? honeyPhases[++index] : spriteRenderer.sprite;
        return (index == honeyPhases.Length - 1);
    }
    //SOMETHING IS WRONG -- HONEY BOTTLES NEED TO ALL BE CENTERED OR ELSE THEYLL IMPLICITLY MOVE AROUND WHEN THEY SHOULDNT

    //switches the array of honey sprites to the easter egg one
    public void EasterEgg() {
        honeyPhases = honeyPhasesAlt;
    }
}
