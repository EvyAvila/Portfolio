using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPlayer : Entity
{
    //The float RotateSpeed is how fast the player will rotate whenever
    //they press the left or right button
    public float RotateSpeed;

    //A public text for the UI that will display the health status
    //to the user
    public Text HealthStatus;

    //A public bool that checks whether the player is in a battle with an enemy
    public bool InBattle { get; set; }

    //A public bool that can allow the player to restart the game if they win or lose
    public bool RestartGame { get; set; }

    // Start is called before the first frame update
    // It sets each value of the variables such as 
    // Speed, DefaultSpeed, and RotateSpeed
    void Start()
    {
        Speed = 5f;
        DefaultSpeed = Speed;
        RotateSpeed = 10;
        Health = 20;
        MaxHealth = Health;

        DisplayHealthText();

        InBattle = false;

    }

    // Update is called once per frame
    // It mainly checks the controller called Movecharacter
    // and Displays the Health status at all times
    void Update()
    {
        if(!InBattle)
        {
            MoveCharacter();
        }

        CheckHealth();

        DisplayHealthText();

        CheckActive(HealthStatus);

    }

    //The method consist a variable called keyboard since I'm using the Input System
    //There are currently four inputs that checks if the selected key was pressed.
    //I have each if statement as single instead of else if because I had the issue
    //of the player stopping when they press the up and right arrow or other. So
    //in case the player wants to go in a diagonal, it's best to have each input
    //have their own if statement. Within each conditional is another method that
    //does the action when a key is pressed. At the buttom of the method checks
    //the speed of the player.

    //I know the comment suggests to change it but I didn't have enough time
    //to change it.
    void MoveCharacter()
    {
        var keyboard = Keyboard.current;

        if (keyboard.upArrowKey.isPressed)
        {
            Direction(Vector3.forward);
        }
        if (keyboard.downArrowKey.isPressed)
        {
            Direction(Vector3.back);
        }
        if (keyboard.leftArrowKey.isPressed)
        {
            RotatingPlayer(-RotateSpeed);
        }
        if (keyboard.rightArrowKey.isPressed)
        {
            RotatingPlayer(RotateSpeed);
        }

        CheckSpeed(keyboard);
    }

    //The method checks a bool condition, mainly RestartGame to see if the player is able to restart.
    //If the player is alive, the method won't run because the condition must be true. If the player won or died,
    //the condition will be true. And if the player presses the r key as well, then the scene reloads to the 
    //start of the game.
    public void RestartTheGame(bool condition)
    {
        var keyboard = Keyboard.current;

        if(keyboard.rKey.isPressed && condition)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            RestartGame = false;
        }
    }

    //The method has a float parameter for when the player rotates. 
    //It's called when the player presses the left or right button.
    //to make the character rotate, I have a transform.Rotate() with the
    //required parameters of the vector3, which mainly focuses on the y axis
    //with the rotate * Speed * Time.detlaTime
    private void RotatingPlayer(float rotate)
    {
        transform.Rotate(0, rotate * Speed * Time.deltaTime, 0);
    }

    //The method has a vector3 parameters that uses transform.Translate()
    //for when the player moves forward or backwards. Similar to the RotatingPlayer 
    //method, it also has theVector * Speed * Time.deltaTime
    private void Direction(Vector3 theVector)//Vector3 theVector)
    {

        transform.Translate(theVector * Speed * Time.deltaTime);
    }

    //The method mainly checks the speed of the player to make sure the player
    //doesn't slide around when they are not moving. If no input is pressed, 
    //the speed is zero. Otherwise, the speed is set at it's default value. 
    private void CheckSpeed(Keyboard keyboard)
    {
        if (!keyboard.anyKey.isPressed)
        {
            Speed = 0;
        }
        else
        {
            Speed = DefaultSpeed;
        }
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
        if (IsDead())
        {
            Health = 0;
            Debug.Log("Dead :(");
            this.gameObject.SetActive(false);
            Speed = 0;
            
        }
        else if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        DisplayHealthText();

    }

    //A method where the HealthSatus sets the text with 
    //the player's health over the total health
    void DisplayHealthText()
    {
        HealthStatus.text = $"{Health} / {MaxHealth}";
    }

    //The collision checks if the player had collided with any enemy with the specifc tag. If so, the bool InBattle will become true
    //and will prevent the player from being able to move around until the battle is over.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BlackHole") || collision.gameObject.CompareTag("Planet") || collision.gameObject.CompareTag("SuperNova"))
        {
            InBattle = true;
        }
        
    }
}
