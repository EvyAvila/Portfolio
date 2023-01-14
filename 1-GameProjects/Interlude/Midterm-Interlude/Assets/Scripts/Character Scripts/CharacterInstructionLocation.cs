using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A script for the player that starts them inside a box 
/// that displays the instructions. 
/// </summary>
public class CharacterInstructionLocation : MonoBehaviour
{

    /// <summary>
    /// The tmp_text which the gameObject will insert which text it will be using.
    /// </summary>
    public TMP_Text InstructionsText;

    /// <summary>
    /// A string holder for what will be displayed in the UI. 
    /// It starts with an set empty string to display the instructions 
    /// and goal of the game.
    /// </summary>
    string TheInstructions = String.Empty;

    // Start is called before the first frame update
    /// <summary>
    /// The Start method displays the text with the 
    /// commands and goals that the player can read before playing
    /// </summary>
    void Start()
    {
        TheInstructions = "Commands:\nPress the UP arrow to move, the LEFT, RIGHT, or DOWN arrow to rotate, and hold SHIFT to accelerate." +
            "\nGoal: \nFind the music sheets that are hidden throughout the maze. There are certain rooms that will require a certain amount of keys to access. Those keys can be found anywhere in the maze." +
            "\n\nPress the H key to start";

        InstructionsText.text = TheInstructions;
    }

    /// <summary>
    /// Update consist of one method that is used to
    /// "activate" the start of the game
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        StartTheGame();
    }

    /// <summary>
    /// THe method gets the input key to move the player
    /// from the cube to the maze
    /// </summary>
    private void StartTheGame()
    {
        if(Input.GetKey(KeyCode.H))
        {
            this.transform.position = new Vector3(325, 317, 295);
            InstructionsText.text = "";
        }
    }
}
