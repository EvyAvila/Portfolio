using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A script for the player that only handles the players location
/// </summary>
public class CharacterLocation : MonoBehaviour
{
    /// <summary>
    /// An array game object that holds the amount of
    /// floors are inside the maze
    /// </summary>
    public GameObject[] floors;

    /// <summary>
    /// A Bounds array that takes into consideration of the 
    /// floors array to set the boundaries or coordinates for
    /// the player to know where the floors are located
    /// </summary>
    private Bounds[] floorsBoundaries;

    /// <summary>
    /// Another Bounds that checks the players boundaries or coordinate 
    /// to allow the player know where they are currently located based on the floors
    /// </summary>
    private Bounds playerBounds;

    /// <summary>
    /// The tmp_text which the gameObject will insert which text it will be using.
    /// </summary>
    public TMP_Text locationText;


    // Start is called before the first frame update
    /// <summary>
    /// The start void is setting the default conditions for when the player
    /// first starts the game. 
    /// It also gets the components of the player bounds and setting each boundary and 
    /// height of the player
    /// </summary>
    void Start()
    {
        playerBounds = transform.GetComponent<MeshRenderer>().bounds;
        
        float heightOfPlayer = playerBounds.size.y;

        floorsBoundaries = new Bounds[floors.Length];

        for(int i = 0; i < floors.Length; i++)
        {
            floorsBoundaries[i] = floors[i].GetComponent<MeshRenderer>().bounds;

            floorsBoundaries[i].Encapsulate(new Vector3(floorsBoundaries[i].center.x,
                heightOfPlayer, floorsBoundaries[i].center.z));

            //Debug.LogFormat("{0}:{1}", i, floorsBoundaries[i].extents);
        }

        FindCurrentLocation(this.gameObject);
    }

    /// <summary>
    /// A method that finds the current location of the player
    /// from the floors array, which will then update the UI.
    /// </summary>
    /// <param name="gameObject"></param>
    private void FindCurrentLocation(GameObject gameObject)
    {
        int floorFound = -1;
        string floorName = String.Empty;

        for(int i = 0; i < floorsBoundaries.Length && floorFound == -1; i++)
        {
            if(floorsBoundaries[i].Contains(gameObject.transform.position))
            {
                floorFound = i;
                floorName = floors[i].gameObject.name;
            }
        }

        if(floorFound != -1)
        {
            //Debug.Log($"Player is on plane {floorName}");
            locationText.text = floorName;
        }
    }

    // Update is called once per frame
    /// <summary>
    /// Checking every frame the current location of the player for 
    /// whenever they decide to move to another location or area of the maze
    /// </summary>
    void Update()
    {
        FindCurrentLocation(this.gameObject);
    }
}
