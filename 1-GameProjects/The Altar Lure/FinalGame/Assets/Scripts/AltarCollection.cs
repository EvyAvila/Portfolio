using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AltarCollection : MonoBehaviour
{
    /// <summary>
    /// A collection of the displayed objects that are invisible 
    /// </summary>
    public GameObject[] DisplayedCollection;

    /// <summary>
    /// A collection of the objects that are active or visible
    /// </summary>
    [SerializeField] private List<GameObject> ActiveCollection;

    /// <summary>
    /// An int that gets the number or length of the array of all the displayed objects
    /// </summary>
    [SerializeField] int CollectionNumber;

    /// <summary>
    /// A gameobject to interact with the player
    /// </summary>
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ActiveCollection = new List<GameObject>();
        CollectionNumber = DisplayedCollection.Length;
    }

    // Update is called once per frame
    void Update()
    {
        CollideWithAlter();

        if(ActiveCollection.Count == CollectionNumber) //Checking if the list count is the same as the collection numbers, it'll set the player state to winner
        {
            MainPlayerController.playerState = PlayerState.Winner;
        }
    }

    /// <summary>
    /// Checks to see if the player has collided with the altar gameobject
    /// </summary>
    void CollideWithAlter()
    {
        if (player.GetComponent<Collider>().bounds.Intersects(this.gameObject.GetComponent<Collider>().bounds))
        {
            CheckAltar();
        }
    }

    /// <summary>
    /// Checks to see if the objects are active in the hierarchy and that it is not the same object, the
    /// object will be added to the list
    /// </summary>
    void CheckAltar()
    {
        foreach(var c in DisplayedCollection) 
        {
            if(c.activeInHierarchy && !ActiveCollection.Contains(c)) 
            {
                ActiveCollection.Add(c);
            }
        }
        
    }
}
