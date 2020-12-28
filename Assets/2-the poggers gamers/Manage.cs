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

        [SerializeField] GameObject background;
        private MiscScript backgroundScript;

        [SerializeField] GameObject table;
        private MiscScript tableScript;

        //makes sure we only activate the easter egg once
        private bool easterEgg;
        private int numSpacesPressed; 

        //getting the relevant scripts from the objects so we can access them
        void Start() {
            beeScript = bee.GetComponent<BeeScript>();
            honeyScript = honey.GetComponent<HoneyScript>();
            backgroundScript = background.GetComponent<MiscScript>();
            tableScript = table.GetComponent<MiscScript>();
            numSpacesPressed = 0;
        }

        //each frame checks for spacebar press and/or easter egg activation
        void Update() {
            checkEasterEgg();
            if(Input.GetKeyDown(KeyCode.Space)) {
                ++numSpacesPressed;
                //TODO: despawn spacebar object at the bottom of screen
                beeScript.SwitchArms();
                //honey does what it needs to on spacebar press
                //method returns true if we finished the bottle (game win) or false if not (game still losing)
                MinigameManager.Instance.minigame.gameWin = honeyScript.ProcessAction(numSpacesPressed);
                Debug.Log(MinigameManager.Instance.minigame.gameWin);                
            }
        }

        //OOOOOOOO SUPER SECRET EASTER EGG!!!!
        //checks for the triggering of the easter egg and handles components correctly
        void checkEasterEgg() {
            if(!easterEgg && Input.GetKeyDown(KeyCode.B)) {
                easterEgg = true;
                beeScript.EasterEgg();
                honeyScript.EasterEgg();
                backgroundScript.EasterEgg();
                tableScript.EasterEgg();
            }
        }
    }
}
