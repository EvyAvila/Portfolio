using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //A list that is meant to change during the game for collecting the main collectable objects
    private List<GameObject> MainCollectable;    

    //An array that holds what the required collectable objects are
    public GameObject[] RequiredCollectable;

    //A game object that collects the name of the collectable
    private GameObject collectable;

    // Start is called before the first frame update
    void Start()
    {
        MainCollectable = new List<GameObject>();
        collectable = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //A method that adds the gameobject into the list
    public void AddToPlayerInventory(GameObject g)
    {
        MainCollectable.Add(g);
    }

    //A trigger point where if the player collected the object, it
    //would be added to their inventory. If the player has
    //the items and returns to the alter, the items will display on
    //the ones the player collected
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Object"))
        {
            collectable = other.gameObject;
            AddToPlayerInventory(collectable);
        }

        if(other.gameObject.CompareTag("Altar"))
        {
            
            foreach(GameObject g in MainCollectable)
            {
                RequiredCollectable.Where(c => c.name == g.name).FirstOrDefault().SetActive(true);
            }

        }



    }
}







