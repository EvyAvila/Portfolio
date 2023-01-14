using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    //A transform that will help find the location or position of the player
    private Transform Player;

    //Getting the script MainPlayer to allow the camera have access to the controller and method of the player.
    public MainPlayer mainPlayer;

    //A vector3 that will set the specific location of the camera based on the 
    //player's position
    public Vector3 PlayerPosition;

    // Start is called before the first frame update
    // The player finds the gameobject that the camera will need to follow.
    // Then the position is set for how far camera will be.
    // Finally, the ability to restart the game is false. 
    void Start()
    {
        Player = GameObject.Find("MainPlayer").transform;
        PlayerPosition = new Vector3(-0.2f, 0.76f, -1.69f);
        mainPlayer.RestartGame = false;
    }

    // Update is called once per frame
    // It set's the transform.position of the camera from the transform of the player
    // and have the camera look at the player
    // It also checks if the player is dead, the condition RestartGame becomes true. Which
    // will allow the method RestartTheGame to become active.
    // The reason why the camera needs the script of main player is because when the player dies,
    // the object becomes inactive. Thus not being able to press any key to restart the game.
    // Since the camera will remain active, it's able to access the script and operate. 
    private void LateUpdate()
    {
        this.transform.position = Player.TransformPoint(PlayerPosition);
        this.transform.LookAt(Player);

        if(mainPlayer.IsDead() )
        {
            mainPlayer.RestartGame = true;
           
        }

        mainPlayer.RestartTheGame(mainPlayer.RestartGame);
    }

   
}
