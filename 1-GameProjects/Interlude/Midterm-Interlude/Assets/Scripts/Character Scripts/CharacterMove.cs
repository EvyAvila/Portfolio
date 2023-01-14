using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for the player that only handles the players movement 
/// </summary>
public class CharacterMove : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// A float value of speed to determine how fast the player can move
    /// </summary>
    float Speed;

    /// <summary>
    /// A public default speed that will initialize the speed for the game
    /// through the inspector. 
    /// </summary>
    public float DefaultSpeed;

    /// <summary>
    /// A public float that increases the speed by a certain amount 
    /// from the original.
    /// </summary>
    public float FasterSpeed;

    /// <summary>
    /// A float value to determine how many steps the player 
    /// can take for the z axis movement
    /// </summary>
    public float MoveValue;

    /// <summary>
    /// The default value for when the MoveValue variable changes
    /// and needs to return to the oringinal value
    /// </summary>
    float DefaultMoveValue = 1;

    /// <summary>
    /// A float value for the player to turn around 
    /// if they choose to look backwards
    /// </summary>
    float RotateInReverse = 180f;

    /// <summary>
    /// A float value for the player to trun 
    /// left or right 
    /// </summary>
    float RotateSide = 90f;

    /// <summary>
    /// The start was mainly used at the start of the project to 
    /// Display text in the debug log. Other then that, it sets the variable
    /// MoveValue from DefaultMoveValue
    /// </summary>
    void Start()
    {
        //Debug.Log("Start print here");
        MoveValue = DefaultMoveValue;
    }

    // Update is called once per frame
    /// <summary>
    /// Update contains a method for moving the player
    /// and updating the Speed value
    /// </summary>
    void Update()
    {
        UpdateSpeed();
        MoveCharacter();
    }

    /// <summary>
    /// The method is to keep the speed constant at all times.
    /// Since the player will be moving faster, the method prevents the speed 
    /// from continuously increasing. 
    /// </summary>
    private void UpdateSpeed()
    {
        if(Input.anyKey)
        {
            Speed = DefaultSpeed;
        }
        else
        {
            Speed = 0;
        }
    }

    /// <summary>
    /// The method is used to accelerate the players speed
    /// based on whether they press either shift key. It helps for the player
    /// to travel faster around the maze.
    /// </summary>
    /// <returns></returns>
    private float Acceleration()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Speed += FasterSpeed;
        }

        return Speed;
    }

    /// <summary>
    /// MoveCharacter checks the players input with the arrow keys
    /// Each condition has a specific method depending on the key
    /// </summary>
    private void MoveCharacter()
    {
        Acceleration();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
           
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            LookBack();
            
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LookLeft();
            
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            LookRight();
        }
    }

    /// <summary>
    /// MoveUp is the only method that contains actual movement 
    /// that uses transform.Translate()
    /// </summary>
    private void MoveUp()
    {
        this.transform.Translate(0, 0, MoveValue * Speed * Time.deltaTime);
    }

    /// <summary>
    /// LookBack Rotates the character and the camera
    /// in 180 degrees. As if looking behind or back 
    /// </summary>
    private void LookBack()
    {
        this.transform.Rotate(0, RotateInReverse, 0);
    }

    /// <summary>
    /// LookLeft rotates the player in a negative 
    /// 90 degree turn to look left
    /// </summary>
    private void LookLeft()
    {
        this.transform.Rotate(0, -RotateSide, 0);
    }

    /// <summary>
    /// LookRight rotates the player in a positive
    /// 90 degree turn to look right
    /// </summary>
    private void LookRight()
    {
        this.transform.Rotate(0, RotateSide, 0);
    }

    /// <summary>
    /// Collision Enter is to prevent the player from passing through the
    /// objects such as walls, doors, etc. 
    /// Uses tag to get all game objects with the specific tag
    /// without having to worry about the specific name of
    /// each object. 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            MoveValue = 0;
        }
    }

    /// <summary>
    /// Collision Exit allows the player to resume movement
    /// with the default move value. 
    /// (Since it becomes 0 during collision)
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        MoveValue = DefaultMoveValue;
    }
}
