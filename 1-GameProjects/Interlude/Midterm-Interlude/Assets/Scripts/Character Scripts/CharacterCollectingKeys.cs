using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A script for the player that only handles collecting keys 
/// and updating the UI. 
/// </summary>
public class CharacterCollectingKeys : MonoBehaviour
{
    /// <summary>
    /// A string holder for what will be displayed in the UI. 
    /// It starts with an emptry string of the amount of Keys collected.
    /// </summary>
    string keysCollectedString = String.Empty;

    /// <summary>
    /// The tmp_text which the gameObject will insert which text it will be using.
    /// </summary>
    public TMP_Text CollectedText;

    /// <summary>
    /// An array of gameOjbect that holds the keys gameObjects.
    /// </summary>
    public GameObject[] KeysCollected;

    /// <summary>
    /// The int holds the value of the amount of keys the
    /// players has collected. It will also be included in the
    /// UI text.
    /// </summary>
    public int KeysAmount = 0;

    /// <summary>
    /// The int is meant to hold the total
    /// amount of keys are places in the maze
    /// for the player to find.
    /// </summary>
    public int KeysTotal;

    // Start is called before the first frame update
    /// <summary>
    /// The start void is setting the default conditions for when the player
    /// first starts the game. 
    /// </summary>
    void Start()
    {
        KeysAmount = 0;

        keysCollectedString = "Keys Collected: " + KeysAmount.ToString() + "/" + KeysTotal.ToString();

        CollectedText.text = keysCollectedString;
    }

   
    /// <summary>
    /// An OnCollisionEnter method that checks whether the player
    /// has interacted with the gameobject. Each time the player
    /// collides or interacts with the object, the amount will increase by 1
    /// and update the UI.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        foreach(var key in KeysCollected)
        {
            if(key.name.Equals(collision.gameObject.name))
            {
                KeysAmount += 1;

                keysCollectedString = "Keys Collected: " + KeysAmount.ToString() + "/" + KeysTotal.ToString();

                CollectedText.text = keysCollectedString;
            }
        }
    }

}
