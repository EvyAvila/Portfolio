using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Setting the speed for the enemy to travel
    private float Speed = 7;

    //Setting the direction for the transform.position
    private Vector3 Direction;
    
    //A state machine to set whether the enemy will be moving horizontal or vertical
    private enum EnemyState { Vertical, Horizontal }

    //An object that is available in the inspector to set the enemy state
    [SerializeField] private EnemyState enemyState;

    //A bool to check whether the enemy has spotted the player
    private bool PlayerSpotted;

    //a game object that will set the MainPlayer after it has entered the trigger point
    private GameObject MainPlayer;

    //Setting the direction and bool to false
    void Start()
    {
        SetDirection();
        PlayerSpotted = false;
    }

    // Checks if the player has been spotted, they changed their direction to follow the player
    void Update()
    {
        if(PlayerSpotted)
        {
            MoveToPlayer();
        }
        else
        {
            transform.Translate(Direction * Speed * Time.deltaTime);
        }
       
    }

    //Checks the collision for the wall and main player. If the enemy hits the wall, they
    //change their direction. If they hit the main player, they stop moving
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            ChangeDirection(enemyState);
        }

        if(collision.gameObject == MainPlayer) 
        {
            MainPlayerController.playerState = PlayerState.Dead;
            Speed = 0;
            Debug.Log("Player is dead D:");
        }
    }

    //Checks the collision from the main player. If the player has entered the trigger point, the
    //game object Main Player is set. Thus, the enemy move towards the player and the player is 
    //considered dead
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Enemy spot player");
            MainPlayer = other.gameObject;
            PlayerSpotted = true;
            MainPlayerController.playerState = PlayerState.Dead; //might switch from static to use event bus.

        }
    }

    //Mainly for the Start method, this is where the direction in which the enemy travel is based 
    //on the state. Vertical state sets the z axis while horizontal state sets the x axis
    private void SetDirection()
    {
        switch(enemyState)
        {
            case EnemyState.Vertical:
                Direction.z = 1;
                break;
            case EnemyState.Horizontal:
                Direction.x = 1;
                break;
            default:
                enemyState= EnemyState.Vertical;
                break;
        }
    }

    //This method checks the enemy state and change it to the opposit direction
    private void ChangeDirection(EnemyState state)
    {
        switch(state) 
        {
            case EnemyState.Vertical:
                Direction.z = -Direction.z;
                break;
            case EnemyState.Horizontal:
                Direction.x = -Direction.x;
                break;
        }
       
    }

    //A method that sets the transform.position to a vector 3 MoveTowards method to follow the player
    //as they are "catching" them.
    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(this.transform.position,  MainPlayer.transform.position,  Speed * Time.deltaTime);
    }

}
