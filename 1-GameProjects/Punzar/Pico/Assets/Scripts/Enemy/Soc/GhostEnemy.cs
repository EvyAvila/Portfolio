using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This enemy is a ghost that mainly tries to push the player against the wall
public class GhostEnemy : EnemyUnity
{
    // Start is called before the first frame update
    void Start()
    {
        Health = 25;
        MaxHealth = Health;
        Speed = 15;
        enemyType = EnemyTypes.Ghosty;

        FollowPlayer = false;
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

        if (collision.gameObject.CompareTag("MainPlayer"))
        {
            FollowPlayer = true;
        }
    }

    public override void Controller()
    {
        base.Controller();

        if (FollowPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }
    }
}
