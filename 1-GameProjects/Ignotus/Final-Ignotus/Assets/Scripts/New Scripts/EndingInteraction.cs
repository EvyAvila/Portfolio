using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingInteraction : MonoBehaviour
{
    //Getting the script MainPlayer to allow the game object have access to the controller and method of the player.
    private MainPlayer Player;

    //A public text that will display an ending result when the player wins the game
    public Text EndingText;

    // Start is called before the first frame update
    // It first finds the gameobject MainPlayer and gets the component MainPlayer.
    // Then the text is set to emtpy because it's not meant to display anything until the end of the game.
    void Start()
    {
        Player = GameObject.Find("MainPlayer").GetComponent<MainPlayer>();
        EndingText.text = "";
    }

    // Update is called once per frame
    // It mainly has the method RestartTheGame checking if the condition RestartGame is true, which if so, will allow the player
    // to replay the game if they want to
    void Update()
    {
        Player.RestartTheGame(Player.RestartGame);
    }

    //Instead of colliding, the object checks the trigger to see if the game object is the MainPlayer.
    //If so, then the text displays a Congratulations, removes the health status, sets the player object to false,
    //and makes the bool RestartGame true.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MainPlayer"))
        {
            EndingText.text = "Congrats! You made it to the end of the universe!";
            Player.HealthStatus.text = "";
            Player.gameObject.SetActive(false);

            Player.RestartGame = true;
        }
    }
}
