using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInteraction : MonoBehaviour
{
    // A public field that gets the health from the MainPlayer
    // cript. It's main purpose is to check on the condition
    // of the player's health to see if they will need to increase their health
    public MainPlayer Player;

    //When the player is close to the star or within the trigger entry
    //it first checks if the gameobject has interacted with the object with
    //the tag MainPlayer. If so, the player's health is check to see if
    //the player has full health. If not, then the object or star destroys
    //and the health increases.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MainPlayer")
        {
            if (Player.Health >= Player.MaxHealth) { } //It does nothing as in the player can't pick up the object
            else
            {
                gameObject.SetActive(false);
                Player.Health += 2;
            }
        }
    }
}
