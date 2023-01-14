using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    // The Health property is where the health can be set for each specific class
    //Note: Some of the enemies health aren't set to the correct number when the Player interacts with them.
    public int Health { get; set; }

    // The MaxHealth is the total health of the player or enemy that is set from
    // the Health
    public int MaxHealth { get; protected set; }

    // The Speed is used to set how fast the objects will be moving
    public float Speed { get; protected set; }

    // The DefaultSpeed is created for times when the objects will stop moving 
    // and will need to move again
    public float DefaultSpeed { get; protected set; }

    //A bool mainly for the enemies, it checks if they are about to fight 
    //the main player
    public bool FightPlayer;

    //A bool method that checks whether the object is dead with less than 
    //or equal to 0.
    public bool IsDead()
    {
        if(Health <= 0)
        {
            Health = 0;
            return true;
        }

        return false;
    }

    //A public method that checks if the enemy game object is active in the Hierarchy. 
    //Since the enemy will be disabled before the text can be cleared, the method makes sure 
    //that the text are "disable"
    public void CheckActive(Text textmessage)
    {
        if(this.gameObject.activeInHierarchy == false)
        {
            textmessage.text = "";
        }
    }

    //A public method that displays the health status of the enemy health when they are about to fight the main player.
    //It helps with having to write the code many times.
    public void DisplayEnemyText(int health, int maxHealth, Text textMessage, bool condition)
    {
        if(condition)
        {
            textMessage.text = $"{health} / {maxHealth}";
        }
       
    }
}
