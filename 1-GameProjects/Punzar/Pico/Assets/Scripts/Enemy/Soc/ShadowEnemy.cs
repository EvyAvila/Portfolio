using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This enemy has a sword that deals double damage. Since they are a shadow, they are invisible until the player reaches the trigger point
public class ShadowEnemy : EnemyUnity
{
    public bool SwordUp { get; set; }

    public GameObject EnemySword1;
    public GameObject EnemySword2;

    private SpriteRenderer SpriteRen;

    // Start is called before the first frame update
    void Start()
    {
        Health = 35;
        MaxHealth = Health;
        Speed = 7;
        enemyType = EnemyTypes.Shadowy;

        FollowPlayer = false;
        SwordUp = false;

        SpriteRen = gameObject.GetComponent<SpriteRenderer>();

        SpriteRen.color = new Color(255,255,255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
        CheckHealth();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        
        if(collision.gameObject.CompareTag("MainPlayer"))
        {
            FollowPlayer = true;
            SwordUp = true;
            SpriteRen.color = new Color(255, 255, 255, 255);
        }
    }

    public override void Controller()
    {
        base.Controller();

        if(FollowPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
            
        }

        if (SwordUp)
        {
            if(Player.position.x < this.transform.position.x)
            {
                EnemySword1.SetActive(true);
                EnemySword2.SetActive(false);
            }
            else if(Player.position.x > this.transform.position.x)
            {
                EnemySword2.SetActive(true);
                EnemySword1.SetActive(false);
            }
        }



    }
}
