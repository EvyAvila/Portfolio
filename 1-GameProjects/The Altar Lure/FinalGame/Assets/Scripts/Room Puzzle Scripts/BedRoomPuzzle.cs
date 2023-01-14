using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoomPuzzle : PuzzleComponent
{
    /// <summary>
    /// Different gameobjects for the purpose of the bedroom activity or puzzle
    /// </summary>
    public GameObject Pillow;
    public GameObject Shelf;
    public GameObject HiddenKey;

    /// <summary>
    /// Bools to check if the player has the key and the pillow moved to get the key
    /// </summary>
    bool HasKey;
    bool PillowMoved;

    /// <summary>
    /// Transform to move the objects to a specific location
    /// </summary>
    private Transform shelfPosition;
    private Transform pillowPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        HasKey = false;
        shelfPosition = GameObject.Find("Shelf1 New Position").GetComponent<Transform>();
        pillowPosition = GameObject.Find("PillowNewLocation").GetComponent<Transform>();
        PillowMoved = false;

    }

    // Update is called once per frame
    void Update()
    {
        InteractInsideRoom();   
    }

    /// <summary>
    /// A method that holds different methods that are always checking
    /// </summary>
    public override void InteractInsideRoom()
    {
        CheckPillow();
        GetKey();
        OpenDrawer();
    }

    /// <summary>
    /// Checks to see if the player has collided with the pillow, it 
    /// sets the bool to true and changes the position of the pillow gameobject
    /// </summary>
    public void CheckPillow()
    {
        if (player.GetComponent<Collider>().bounds.Intersects(Pillow.GetComponent<Collider>().bounds))
        {
            Pillow.transform.position = pillowPosition.position; //new Vector3(1 * 0.75f * Time.deltaTime, 0, 0);
            PillowMoved = true;
            
        }
    }

    /// <summary>
    /// Checks to see if the player collides with the key and the pillow has been moved. If so,
    /// the player "collects" the key and deactivates the key
    /// </summary>
    private void GetKey()
    {
        if (player.GetComponent<Collider>().bounds.Intersects(HiddenKey.GetComponent<Collider>().bounds) && PillowMoved)
        {
            HasKey = true;
            HiddenKey.SetActive(false);
        }
    }

    /// <summary>
    /// Checks to see if the player has collided with the drawer and has the key. If so,
    /// the shelft "opens" by moving to another location
    /// </summary>
    public void OpenDrawer()
    {
        if(player.GetComponent<Collider>().bounds.Intersects(Shelf.GetComponent<Collider>().bounds) && HasKey)
        {
           
            Shelf.transform.position = shelfPosition.position; 
        }
    }
    

   
}


/// <summary>
/// A class that acts as a base with the main components of the gameobject and method
/// </summary>
public abstract class PuzzleComponent : MonoBehaviour
{
    public GameObject player;

    public virtual void InteractInsideRoom()
    {

    }

}
