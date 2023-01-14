using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for the music sheets when the player interacts with it
/// </summary>
public class MusicSheetInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary> 
    /// A collision that checks if the player has collided with the music sheets.
    /// Originally had the music sheet object deleted, but received an red error during 
    /// testing about deleting an object that had already been deleted.
    /// Instead of having risks or further errors, my current solution at 
    /// the moment is to move the music sheet to another location
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //Destroy(this.transform.gameObject);
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
}
