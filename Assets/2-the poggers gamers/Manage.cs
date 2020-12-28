using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThePoggersGamers {
    public class Manage : MonoBehaviour
    {
        //objects and their associated scripts that this manager needs
        [SerializeField] GameObject bee;
        private BeeScript beeScript;

        [SerializeField] GameObject honey;
        private HoneyScript honeyScript;

        //after clearing this many honey bottles, win the game if time isn't up
        [SerializeField] int numWinHoneyBottles;

        //makes sure we only activate the easter egg once
        private bool easterEgg;
        private int numSpacesPressed; 
        private int numHoneyBottles;

        //getting the relevant scripts from the objects so we can access them
        void Start() {
            beeScript = bee.GetComponent<BeeScript>();
            honeyScript = honey.GetComponent<HoneyScript>();
            numSpacesPressed = 0;
        }

        //each frame checks for spacebar press and/or easter egg activation
        void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                ++numSpacesPressed;
                //TODO: despawn spacebar object at the bottom of screen
                beeScript.SwitchArms();
                //honey does what it needs to on spacebar press
                //spawnNewBottle is true if we have to switch to a new bottle of honey
                bool spawnNewBottle = honeyScript.ProcessAction(numSpacesPressed);
                if(spawnNewBottle) {
                    ++numHoneyBottles;
                    //switches honey bottles to keep game going
                    SwitchHoney();
                }
                //check the win condition, update if necessary (using ternary operator)
                //game doesn't end right away, so keep win condition true even if we've already hit number to win
                MinigameManager.Instance.minigame.gameWin = (numHoneyBottles >= numWinHoneyBottles) ? true : false;
            }
            checkEasterEgg();
        }

        //despawn empty honey and spawn new honey
        //thing at the top to show how many bottles you've eaten? Update? Or maybe just have full bottles visible one one side of table and empty bottles on the other, and update those sprites? 
        void SwitchHoney() {

        }

        //OOOOOOOO SUPER SECRET EASTER EGG!!!!
        //checks for the triggering of the easter egg and handles components correctly
        void checkEasterEgg() {
            if(!easterEgg && Input.GetKeyDown(KeyCode.B)) {
                easterEgg = true;
                beeScript.EasterEgg();
                honeyScript.EasterEgg();
                //background.GetComponent<SpriteRenderer>().sprite = backgroundAlt;
                //OR backgroundScript.EasterEgg();
            }
        }
    }
}
