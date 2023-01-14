using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState { Idle, Running, Die, Win}

public class MainPlayer : MonoBehaviour
{
    public Vector2 Direction = new Vector2(1, 0);
    public float Speed = 10f;

    public PlayerState playerState;

    private Vector3 moveTranslate;

    private MainPlayerController controller;
    public Animator animator;

    public int HealthAmount;
    public int HealthTotalAmount { get; private set; }

    public GameObject SwordOne;
    public GameObject SwordTwo;

    public Text DisplayHealthText, PlayerDiedText;

    public Sprite BehindSprite, FrontSprite;
    
    // Start is called before the first frame update
    public void Start()
    {
        controller = GetComponent<MainPlayerController>();

        HealthAmount = 20;

        HealthTotalAmount = HealthAmount;

        playerState = PlayerState.Idle;

        DisplayHealthMethod();
        PlayerDiedText.text = "";
    }

    private bool IsAlive = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        DisplayHealthMethod();

        if (IsAlive && playerState != PlayerState.Win)
        {
            UpdatePlayerController();
            UpdateMovePlayer();
            ActivateWeapon();
        }

        if(playerState == PlayerState.Win)
        {
            RestartGame.CanRestart = true;
            this.controller.ResetGame();
        }
           
        
        CheckPlayerHealth();
    }

    private void UpdatePlayerController()
    {
        if(this.controller.IsKeyDown)
        {
            this.Direction = this.controller.ControllerDirection;
            playerState = PlayerState.Running;
            
        }
        else
        {
            this.Direction = new Vector2(0, 0);
            playerState = PlayerState.Idle;
        }
    }

    private void UpdateMovePlayer()
    {
        this.moveTranslate = new Vector3(this.Direction.x, this.Direction.y) * Time.deltaTime * this.Speed;
        this.transform.position += new Vector3(this.moveTranslate.x, this.moveTranslate.y);
    }

    void CheckPlayerHealth()
    {
        if(HealthAmount <= 0)
        {
            HealthAmount = 0;

            PlayerDiedText.text = "You died. Press r to restart.";

            IsAlive = false;
            RestartGame.CanRestart = true;
            playerState = PlayerState.Die;
            this.controller.ResetGame();
        }
    }

    private void ActivateWeapon()
    {
        this.controller.FightController();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HealthAmount -= 1;
        }

        if(collision.gameObject.tag == "Wall")
        {
            HealthAmount -= 1;
        }    
    }

    private void DisplayHealthMethod()
    {
        DisplayHealthText.text = $"Health: {HealthAmount} / {HealthTotalAmount}";
    }

}
