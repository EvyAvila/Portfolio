using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A script for the player that only handles collecting music sheets 
/// and updating the UI. 
/// </summary>
public class CharacterCollectingMusicSheets : MonoBehaviour
{
    /// <summary>
    /// A string holder for what will be displayed in the UI. 
    /// It starts with an emptry string of the amount of
    /// music sheets collected.
    /// </summary>
    string musicSheetsCollected = String.Empty;

    /// <summary>
    /// The tmp_text which the gameObject will insert which text it will be using.
    /// </summary>
    public TMP_Text CollectedMusicSheets;

    /// <summary>
    /// An array of gameOjbect that holds the 
    /// music sheet gameObjects.
    /// 
    /// Removed/Not in use
    /// </summary>
    //public GameObject[] SheetsCollected;

    /// <summary>
    /// The int holds the value of the amount of music sheets the
    /// players has collected. It will also be included in the
    /// UI text.
    /// </summary>
    public int SheetsAmount = 0;

    /// <summary>
    /// The int displays the total amount of sheets the 
    /// player needs to find inside the maze.
    /// </summary>
    public int SheetsTotal;

    /// <summary>
    /// An empty string that contains the text 
    /// to display the end game result
    /// </summary>
    string EndGameResult = String.Empty;

    /// <summary>
    /// The tmp_text which the gameObject will insert which text it will be using.
    /// </summary>
    public TMP_Text EndGameText;

    // Start is called before the first frame update
    /// <summary>
    /// The start void is setting the default conditions for when the player
    /// first starts the game. 
    /// It also starts the end game result variable as empty to hide the text
    /// </summary>
    void Start()
    {
        SheetsAmount = 0;

        musicSheetsCollected = "Music Sheets Collected: " + SheetsAmount.ToString() + "/" + SheetsTotal.ToString();

        CollectedMusicSheets.text = musicSheetsCollected;

        EndGameResult = "";
        EndGameText.text = EndGameResult;
    }

    /// <summary>
    /// Update only consist of EndGame method to display the 
    /// result once the player collects all the music sheets
    /// </summary>
    private void Update()
    {
        EndGame();
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
        #region OriginalCode
        /*
        foreach(var sheet in SheetsCollected)
        {
            if(sheet.name.Equals(collision.gameObject.name))
            {
                SheetsAmount += 1;

                musicSheetsCollected = "Music Sheets Collected:" + SheetsAmount.ToString() + "/" + SheetsTotal.ToString();

                CollectedMusicSheets.text = musicSheetsCollected;
            }
        }*/
        #endregion
        
        if (collision.gameObject.tag == "MusicSheet")
        {
            SheetsAmount += 1;
            musicSheetsCollected = "Music Sheets Collected:" + SheetsAmount.ToString() + "/" + SheetsTotal.ToString();

            CollectedMusicSheets.text = musicSheetsCollected;
        }

    }

    /// <summary>
    /// After checking if the sheet amount is equal to the 
    /// total amount, it'll update the text to display to the
    /// player that they have won
    /// </summary>
    private void EndGame()
    {
        if(SheetsAmount == SheetsTotal)
        {
            EndGameResult = "You've won!";
            EndGameText.text = EndGameResult;
            gameObject.GetComponent<CharacterMove>().MoveValue = 0;
        }
        else
        {
            EndGameResult = "";
            EndGameText.text = EndGameResult;
        }
    }
}
