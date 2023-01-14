using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A script for the door game objects for when the player interacts with
/// </summary>
public class DoorInteraction : MonoBehaviour
{
    /// <summary>
    /// A string holder for what will be displayed in the UI. 
    /// It starts with an emptry string of the door encounterment
    /// </summary>
    string DoorEncounter = String.Empty;

    /// <summary>
    /// The tmp_text which the gameObject will insert which text it will be using.
    /// </summary>
    public TMP_Text TheDoorText;
    
    /// <summary>
    /// Calling a reference of the script to takes into consideration 
    /// how many keys have been collected
    /// </summary>
    public CharacterCollectingKeys AmountOfKeys;

    /// <summary>
    /// Each door has a specific amout of keys that are needed to 
    /// open the door that is set in the inspector.
    /// </summary>
    public int NumberOfKeysNeeded;

    // Start is called before the first frame update
    /// <summary>
    /// The start void is setting the default conditions for when the player 
    /// first starts the game.
    /// It also finds the player game object to get the component or script for the 
    /// Amount of keys that have been collected over the time of the game
    /// </summary>
    void Start()
    {
        DoorEncounter = "";
        TheDoorText.text = DoorEncounter;
        //Calling from script
        AmountOfKeys = GameObject.Find("Player").GetComponent<CharacterCollectingKeys>();
        
    }

    /// <summary>
    /// OnCollisionEnter checks the condition of the door.
    /// If the player has the amount of keys equal to the required amount
    /// of keys, the door will open.
    /// Otherwise, the player will receive a text that displays "Cannot Open"
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //want to check if keys goes up - complete

        if(collision.gameObject.name == "Player" && AmountOfKeys.KeysAmount >= NumberOfKeysNeeded) //Checks if player collide and has the amount of keys needed to "open"
        {
            //Destroy(this.transform.gameObject);
            this.transform.position = new Vector3(0, 0, 0);
        }
        else if(collision.gameObject.name == "Player" && AmountOfKeys.KeysAmount < NumberOfKeysNeeded) //Checks if player collides but the amount of keys is lower than required
        {
            //Debug.Log($"Attempt to open door");
            DoorEncounter = $"Cannot Open. Need {NumberOfKeysNeeded} key(s)";
            TheDoorText.text = DoorEncounter;
        }
    }

    /// <summary>
    /// When the player leaves or exits the collision, 
    /// it sets the UI as empty to get rid of any previous text
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            DoorEncounter = "";
            TheDoorText.text = DoorEncounter;
        }
    }
}
