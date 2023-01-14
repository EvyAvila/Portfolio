using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Enemy1, Enemy2, Enemy3, Enemy4, Enemy5, dead, stop}

public class Enemy : MonoBehaviour
{
    public float Speed = 5f;

    public Transform Player;

    public MainPlayer mainPlayer;

    public EnemyState enemyState;

    public int EnemyHealth;
    public int EnemyTotalHealth { get; private set; }

    private EnemyControllers controller;

    public bool FollowPlayer;
    public bool ShootPlayer;

    public bool RegularEnemy { get; set; }
    public bool ShooterEnemy { get; set; }
    public bool InvisibleEnemy { get; set; }
    public bool BombEnemy { get; set; }
    public bool ShadowEnemy { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = 15;
        EnemyTotalHealth = EnemyHealth;
        controller = GetComponent<EnemyControllers>();
        FollowPlayer = false;
        ShootPlayer = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (enemyState)
        {
            case EnemyState.Enemy1:
                controller.EnemyOneController();
                break;
            case EnemyState.Enemy2:
                controller.EnemyTwoController();
                break;
            case EnemyState.Enemy3:
                //Get enemy 3 controller
                controller.EnemyThreeController();
                break;
            case EnemyState.Enemy4:
                controller.EnemyFourController();
                break;
            case EnemyState.Enemy5:
                controller.EnemyFiveController();
                break;

            case EnemyState.dead:
                Destroy(gameObject);
                break;
        }
        CheckHealth();
    }

    void CheckHealth()
    {
        if(EnemyHealth <= 0)
        {
            enemyState = EnemyState.dead;
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.gameObject == mainPlayer.SwordOne || collision.gameObject.gameObject == mainPlayer.SwordTwo)
        {
            EnemyHealth -= 1;
            
        }
    }


}
