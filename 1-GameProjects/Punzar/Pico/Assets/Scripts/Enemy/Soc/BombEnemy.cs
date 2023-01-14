using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This enemy is an instant kill as it's meant to be a bomb
public class BombEnemy : EnemyUnity
{
    private bool PlayerEnter;

    private SpriteRenderer SpriteRen;
    public Sprite NewSprite;

    private BoxCollider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        PlayerEnter = false;

        SpriteRen = gameObject.GetComponent<SpriteRenderer>();

        collision = GetComponent<BoxCollider2D>();

        Health = 5;
        MaxHealth = Health;
        Speed = 0;
        enemyType = EnemyTypes.Bomby;
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
            PlayerEnter = true;
        }
    }

    public override void Controller()
    {
        base.Controller();

        if(PlayerEnter)
        {
            SpriteRen.sprite = NewSprite;
        }

        if(collision.IsTouching(Player.GetComponent<BoxCollider2D>()))
        {
            mainPlayer.HealthAmount = 0;
            Destroy(this.gameObject);
        }
    }

}
