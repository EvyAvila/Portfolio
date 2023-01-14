using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// State machine of three main parts
/// </summary>
public enum PlayerState { Alive, Dead, Winner}

public class MainPlayerController : Subject
{
    /// <summary>
    /// The float is the general speed for the movement
    /// </summary>
    private float Speed = 7;

    /// <summary>
    /// The player will have the ability to run, which is
    /// slightly a faster speed
    /// </summary>
    private float RunningSpeed = 16;

    /// <summary>
    /// This gets the default speed for when the player isn't running,
    /// it returns back. It acts like a placeholder
    /// </summary>
    private float DefaultSpeed;

    /// <summary>
    /// This is the speed in which the player is rotating. Testing
    /// the right speed amount for rotation. (Hence the comment "feels slow")
    /// </summary>
    private float RotateSpeed = 40; //feels slow

    /// <summary>
    /// The vector to update the direction for the player's movement
    /// </summary>
    private Vector3 Direction;

    /// <summary>
    /// Objects to prevent typing out entire value for Input
    /// </summary>
    

    /// <summary>
    /// A bool to check if the player can run. Mainly used to prevent
    /// the player from going through wall with the running speed
    /// </summary>
    private bool CanRun = true;

    /// <summary>
    /// Getting the default to use the new input system
    /// </summary>
    private DefaultMainPlayerInput defaultMainPlayerInput;

    /// <summary>
    /// Input Actions for each main controllers from moving, rotating, and running
    /// </summary>
    private InputAction MoveAction;
    private InputAction RotateAction;
    private InputAction RunAction;

    /// <summary>
    /// A state machine that checks the players state within this class and other classes. 
    /// It's static so that it can change if the player interacts with the enemy, it switches
    /// the state from alive to dead. If the player collects all the items and displays them
    /// in the altar, it switches from alive to winner.
    /// </summary>
    public static PlayerState playerState;

    /// <summary>
    /// Getting the camera for the purpose of rotating along with the player
    /// </summary>
    public Camera mainCamera;

    /// <summary>
    /// A bool that changes if the player has enter a room
    /// </summary>
    public bool HasEnterRoom;

    /// <summary>
    /// A string to set the name of the room the player has entered
    /// </summary>
    public string RoomName;

    /// <summary>
    /// Setting the default input for the script to use
    /// </summary>
    private void Awake()
    {
        defaultMainPlayerInput = new DefaultMainPlayerInput();
    }


    /// <summary>
    /// Setting some of the fields for their respected values
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        DefaultSpeed = Speed;
        playerState = PlayerState.Alive;
    }

    /// <summary>
    /// Checking each state, if the player is alive, they can use the controller. If they are dead or won,
    /// it goes to the next scene
    /// </summary>
    void FixedUpdate()
    {
        switch(playerState) 
        {
            case PlayerState.Alive:
                MoveController();
                break; 
            case PlayerState.Dead:
            case PlayerState.Winner:
                SceneManager.LoadScene(2);
                break;
        }
       
    }

    /// <summary>
    /// Setting each of the input actions to their main components to use specific key buttons.
    /// Also attaching the rooms for the player
    /// </summary>
    private void OnEnable()
    {
        MoveAction = defaultMainPlayerInput.Player.Move;
        MoveAction.Enable();

        RotateAction = defaultMainPlayerInput.Player.Rotate;
        RotateAction.Enable();

        RunAction = defaultMainPlayerInput.Player.Run;
        RunAction.Enable();

        GameObject[] rooms = GameObject.FindGameObjectsWithTag("RoomLocation");
        foreach (GameObject r in rooms)
        {
            Room RoomScriptcomponent = r.GetComponent<Room>();
            Attach(RoomScriptcomponent);
        }

    }

    /// <summary>
    /// Disabling the input and detaching the room observers
    /// </summary>
    private void OnDisable()
    {
        MoveAction.Disable();
        RotateAction.Disable();
        RunAction.Disable();

        GameObject[] rooms = GameObject.FindGameObjectsWithTag("RoomLocation");
        foreach (GameObject r in rooms)
        {
            Room RoomScriptcomponent = r.GetComponent<Room>();
            Detach(RoomScriptcomponent);
        }

    }

    /// <summary>
    /// Contain a method for rotating, moving, and running in
    /// different methods. Mainly, to have each part separated
    /// for their respected actions.
    /// </summary>
    private void MoveController()
    {
        CharacterRotating();

        CharacterMoving();

        RunFaster();
    }

    /// <summary>
    /// Checks the rotation for either the input pressed the 
    /// left or right key
    /// </summary>
    public void CharacterRotating()
    {
        var value = RotateAction.ReadValue<Vector2>();
        transform.Rotate(0, value.x * RotateSpeed * Time.deltaTime, 0);
        mainCamera.transform.rotation = this.transform.rotation; //This is where the camera is able to rotate
    }

    /// <summary>
    /// Checks the direction for either the input pressed
    /// the up or down key and move according
    /// </summary>
    private void CharacterMoving()
    {
        //Used from https://forum.unity.com/threads/unity-input-system-move-along-z-axis.961165/
        var value = MoveAction.ReadValue<Vector2>();
        Direction.z = value.y;

        transform.Translate(Direction * Speed * Time.deltaTime);
        NotifyObserver();
        
    }

    /// <summary>
    /// A float that returns the speed that checks if the player can
    /// run and press the shift key. Else, the speed value returns
    /// to the default value
    /// </summary>
    /// <returns></returns>
    private float RunFaster()
    {
        var ShiftValue = RunAction.ReadValue<float>();

        if(ShiftValue > 0 && CanRun)
        {
            Speed = RunningSpeed;
        }
        else
        {
            Speed = DefaultSpeed;
        }

        return Speed;
    }

    /// <summary>
    /// Checks to see if the player has collided to the wall, they can't run
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            CanRun = false;
        }
    }

    /// <summary>
    /// Checks to see if the player is no longer touching the wall, they can run
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            CanRun = true;
        }
    }

    /// <summary>
    /// Checks to see if the player has entered any room, it notifies the observers
    /// and sets the name of the room. It also sets the bool HasEnterRoom to true
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RoomLocation"))
        {
            HasEnterRoom = true;
            RoomName = other.name;
            NotifyObserver();
        }
    }

   
    /// <summary>
    /// Sets the bool HasEnterRoom to false and change the UI from the name 
    /// of the room to a default string value
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RoomLocation"))
        {
            PlayerUI.RoomLabel.text = "Hallway";
            HasEnterRoom = false;
            
        }
    }



}
