using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//NO LONGER USING, JUST AS REFERENCE
public class CharacterMove : MonoBehaviour
{
    //The float Speed is used for how fast the player will move 
    //from the input to forward or backwards.
    public float Speed;

    //The float DefaultSpeed receives the value from speed had holds the value
    //since Speed will change to 0 when the player stops moving. To make sure 
    //the player can move again, Speed will recieve it's value back from the default.
    //Look at CheckSpeed method for better understanding
    private float DefaultSpeed;

    //The float RotateSpeed is how fast the player will rotate whenever
    //they press the left or right button
    public float RotateSpeed;

    // Start is called before the first frame update
    // It sets each value of the variables such as 
    // Speed, DefaultSpeed, and RotateSpeed
    void Start()
    {
        Speed = 5f;
        DefaultSpeed = Speed;
        RotateSpeed = 10;
    }

    // Update is called once per frame
    // It mainly checks the controller called Movecharacter
    void Update()
    {
       MoveCharacter();
       
    }

    //public InputActionReference triggerAction;

    //public PlayerInput playerInput;

    //The method consist a variable called keyboard since I'm using the Input System
    //There are currently four inputs that checks if the selected key was pressed.
    //I have each if statement as single instead of else if because I had the issue
    //of the player stopping when they press the up and right arrow or other. So
    //in case the player wants to go in a diagonal, it's best to have each input
    //have their own if statement. Within each conditional is another method that
    //does the action when a key is pressed. At the buttom of the method checks
    //the speed of the player.
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
}
