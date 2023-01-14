using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KitchenRoomPuzzle : PuzzleComponent
{
    /// <summary>
    /// A collection of Ingredients that are found in the kitchen
    /// </summary>
    public GameObject[] IngredientsContainment;

    /// <summary>
    /// Mainly to check if the amount in the players inventory matches with the array length 
    /// </summary>
    public int InventoryAmount;

    /// <summary>
    /// A gameobject where the bowl is hiding the food and will deactivate if the player 
    /// collects all the ingredients
    /// </summary>
    public GameObject Bowl;

    /// <summary>
    /// This is to check if the player has collided with the different ingredients
    /// </summary>
    private bool HasCollided;

    // Start is called before the first frame update
    void Start()
    {
        Bowl.SetActive(false);   
        HasCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        RunKitchenPuzzle();
    }

    /// <summary>
    /// Setting the bowl to be active or deactive depending on the bool method.
    /// It also checks the contact make from the player, and collecting
    /// the ingredients
    /// </summary>
    private void RunKitchenPuzzle()
    {
        Bowl.SetActive(HasIngredients());
        CheckContact();
        CollectingIngredient();
    }

    /// <summary>
    /// If the int and length of the array are the same, the bowl with deactivate
    /// </summary>
    /// <returns></returns>
    bool HasIngredients()
    {
        if(InventoryAmount == IngredientsContainment.Length)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if the bool is true, it increases the InventoryAmount by 1 and sets
    /// the bool back to false
    /// </summary>
    void CollectingIngredient()
    {
        switch (HasCollided)
        {
            case true:
                InventoryAmount += 1;
                HasCollided = false;
                break;
        }
    }

    /// <summary>
    /// Checks through the containment and checking if the player has collided and it's active
    /// in the hierarchy. If so, the bool has been set to true and the specific ingredients is 
    /// deactivated
    /// </summary>
    void CheckContact()
    {
        for (int i = 0; i < IngredientsContainment.Length; i++)
        {
            if (player.GetComponent<Collider>().bounds.Intersects(IngredientsContainment[i].GetComponent<Collider>().bounds) 
                && IngredientsContainment[i].activeInHierarchy)
            {
                HasCollided = true;
                IngredientsContainment[i].SetActive(false);
            }
            
        }

    }



   
}
