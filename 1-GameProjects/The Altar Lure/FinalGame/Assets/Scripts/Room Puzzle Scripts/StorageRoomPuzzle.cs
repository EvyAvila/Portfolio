using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class StorageRoomPuzzle : PuzzleComponent
{
    /// <summary>
    /// A list that holds the different storage boxes found in the room
    /// </summary>
    public List<GameObject> StorageBoxes;
    

    /// <summary>
    /// Adding all the storage boxes into the list
    /// </summary>
    void Start()
    {
        AddToList();
    }

    // Update is called once per frame
    void Update()
    {
        OpenBox();   
    }

    /// <summary>
    /// Checks to see if the player has collided with the box, it's deactivated
    /// </summary>
    void OpenBox()
    {
        for (int i = 0; i < StorageBoxes.Count; i++)
        {
            if (player.GetComponent<Collider>().bounds.Intersects(StorageBoxes[i].GetComponent<Collider>().bounds) )
            {

                StorageBoxes[i].SetActive(false);
            }

        }
    }

    /// <summary>
    /// A method that finds all the names of the objects with the tag BoxLid. After 
    /// finding and adding them to the local array, they are then added to the 
    /// StorageBoxes list
    /// An experiment that I made to prevent manually adding all the objects
    /// </summary>
    void AddToList()
    {
        GameObject[] TopBoxed = GameObject.FindGameObjectsWithTag("BoxLid");
        for(int i = 0; i < TopBoxed.Length; i++)
        {
            StorageBoxes.Add(TopBoxed[i]);
        }
    }
}
