using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    //Getting the script MainPlayer to allow the camera have access to the controller and method of the player.
    public MainPlayer Player;

    //A public vector to have the light follow the direction of the player
    public Vector3 Direction;

    //A private int variable that sets the height or y value of the lighting position instead of hard coding the number.
    private int LightHeight;

    // Start is called before the first frame update
    //Direction sets its values from the main player's transform position
    void Start()
    {
        SetDirection();

        LightHeight = 5;
    }

    // Update is called once per frame
    // Direction must know when the player is moving at all times, which is why it's repeated again inside update
    // Then the transform position receives the values of the directions. Then there is the y value with a set number to 
    // allow height, as the light will be shining down on the player
    void Update()
    {
        SetDirection();

        transform.position = new Vector3(Direction.x, LightHeight, Direction.z);
    }

    //The method sets the vector direction for both the Start and Update methods
    private void SetDirection()
    {
        Direction = Player.transform.position;
    }
}
