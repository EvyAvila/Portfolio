using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//NO LONGER USING, JUST AS REFERENCE
public class CharacterHealth : MonoBehaviour
{
    //A public int value that can be changed in the inspector or set within
    //the script that sets the health for the player
    public int PlayerHealth;

    //A property that can get access but is only set within the class. 
    //Its main purpose is to keep the total amount of health the
    //character has
    public int PlayerTotalHealth { get; private set; }

    //A public text for the UI that will display the health status
    //to the user
    public Text HealthStatus;

    //A private script that is meant to get the field Speed for when the
    //player dies. The script is part of the game object so I didn't 
    //need to make it public
    private CharacterMove controller;

    //public GameController gameController;

    // Start is called before the first frame update
    // The player's total heatlh is assigned based on the player's health
    // that is set from the inspector. A method called DisplayHealtText starts
    // the UI. Finally, the controller gets the component from the CharacterMove
    // script.
    void Start()
    {
        //PlayerHealth = (int)gameController.playerHealth.value;

        PlayerTotalHealth = PlayerHealth;

        DisplayHealthText();
        
        controller = GetComponent<CharacterMove>();
        
    }

    // Update is called once per frame
    // It only contains a method called CheckHealth, which is the 
    // status on the player's health value
    void Update()
    {
        //PlayerHealth = (int)gameController.playerHealth.value;
        CheckHealth();
    }

    //The method has a conditional if statement to see if the player's health
    //is less than or equal to 0, the value is first set to 0 in case the value
    //goes into the negatives. Then currently I have a debug log that tells the 
    //console that the player has died. Finally, the controller gets the speed
    //varible and set's it to 0 to prevent the player from moving.
    //I also have an else if statement, which checks if the player's health
    //is greater than the total heatlh, than the health is set to the total health.
    //It's to prevent the number from increasing higher than the total. For example
    // 21/20
    //At the bottom is the method DisplayHealthText that updates the UI if there
    //were any changes
    void CheckHealth()
    {
        if(PlayerHealth <= 0)
        {
            PlayerHealth = 0;
            Debug.Log("Dead :(");
            controller.Speed = 0;
        }
        else if(PlayerHealth > PlayerTotalHealth)
        {
            PlayerHealth = PlayerTotalHealth;
        }

        DisplayHealthText();
        
    }

    //A method where the HealthSatus sets the text with 
    //the player's health over the total health
    void DisplayHealthText()
    {
        HealthStatus.text = $"{PlayerHealth} / {PlayerTotalHealth}";
    }
}
