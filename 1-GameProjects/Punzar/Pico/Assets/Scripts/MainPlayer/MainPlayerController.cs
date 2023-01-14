using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainPlayerController : MainPlayer
{
    protected Vector3 keyDirection;

    protected Vector3 controllerDirection;

    private SpriteRenderer SpriteRen;

    public Vector3 ControllerDirection
    {
        get { return this.controllerDirection; }
    }

    public bool IsKeyDown
    {
        get
        {
            if(keyDirection.sqrMagnitude == 0)
            {
                return false;
            }

            return true;
        }
    }

    private float defaultSpeed; 
    public MainPlayerController()
    {
        controllerDirection = new Vector3();
        keyDirection = new Vector3();
    }

    // Start is called before the first frame update
    public new void Start()
    {
        playerState = PlayerState.Idle;
        SpriteRen = gameObject.GetComponent<SpriteRenderer>();
        defaultSpeed = Speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateKeyboardDirection();
        controllerDirection += keyDirection;
        controllerDirection.Normalize();
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        var keyboard = Keyboard.current;

        if (keyboard.anyKey.isPressed)
        {
            Speed = defaultSpeed;
        }
        else
        {
            Speed = 0;
        }
    }

    protected virtual void UpdateKeyboardDirection()
    {
        keyDirection.x = keyDirection.y = 0;
        

        var keyboard = Keyboard.current;
        animator.SetFloat("Speed", Speed);


        if (keyboard.rightArrowKey.isPressed)
        {
            keyDirection.x += 1;
            SpriteRen.flipX = false;
        }

        if (keyboard.leftArrowKey.isPressed)
        {
            keyDirection.x += -1;
            SpriteRen.flipX = true;
        }

        if (keyboard.upArrowKey.isPressed)
        {
            keyDirection.y += 1;
            
        }

        if (keyboard.downArrowKey.isPressed)
        {
            keyDirection.y += -1;
        }
        
        
        Direction = keyDirection;
        Direction.Normalize();        
    }

    public virtual void FightController()
    {
        var keyboard = Keyboard.current;

        if (keyboard.aKey.isPressed && playerState != PlayerState.Die)
        {
            ActiveSword(true);

        }
        else if(playerState == PlayerState.Die)
        {
            Speed = 0;
            ActiveSword(false);

        }
        else
        {
            ActiveSword(false);
        }
    }

    private void ActiveSword(bool condition)
    {
        SwordOne.SetActive(condition);
        SwordTwo.SetActive(condition);
    }

    public void ResetGame()
    {
        //Reset Game
        var keyboard = Keyboard.current;

        if (keyboard.rKey.isPressed && RestartGame.CanRestart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            RestartGame.CanRestart = false;
        }
    }
}
