using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//General Enemy script

public enum EnemyTypes { Punchy, Shooty, Ghosty, Bomby, Shadowy, Dead}

public class EnemyUnity : MonoBehaviour
{
    public float Speed = 5f;

    public MainPlayer mainPlayer;
    public Transform Player;

    public EnemyTypes enemyType;

    public int Health;

    public int MaxHealth;

    public bool FollowPlayer { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckHealth()
    {
        if(Health <= 0)
        {
            enemyType = EnemyTypes.Dead;
            Destroy(gameObject);
        }
    }

    public virtual void Controller()
    {
       //Empty, will be override
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.gameObject == mainPlayer.SwordOne || collision.gameObject.gameObject == mainPlayer.SwordTwo)
        {
            Health -= 1;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Empty, will be override
    }
}
