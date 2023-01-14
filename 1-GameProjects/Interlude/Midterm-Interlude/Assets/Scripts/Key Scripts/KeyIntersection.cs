using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for the key game objects to handle its interaction
/// </summary>
public class KeyIntersection : MonoBehaviour
{
   /// <summary> 
   /// A collision that checks if the player has collided with the key.
   /// Originally had the key object deleted, but received an red error during 
   /// testing about deleting an object that had already been deleted.
   /// Instead of having risks or further errors, my current solution at 
   /// the moment is to move the key to another location
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
