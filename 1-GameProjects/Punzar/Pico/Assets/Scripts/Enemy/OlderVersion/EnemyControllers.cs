using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllers : Enemy
{
    private float BulletSpeed = 600f;
    public GameObject Bullet;
    private float FireRate = 2000f;// 2 seconds
    
    private float ShootTime;
    public bool PlayerIncomeHorizontal;
    public bool PlayerIncomeVertical;

    private SpriteRenderer SpriteRen;
    public Sprite NewSprite;

    private bool PlayerEnter = false;

    public bool SwordUp { get; set; }

    private BoxCollider2D collision;

    public GameObject EnemySword1;
    public GameObject EnemySword2;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRen = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MainPlayer")
        {
            switch(enemyState)
            {
                case EnemyState.Enemy1:
                    FollowPlayer = true;
                    break;
                case EnemyState.Enemy2:
                    ShootPlayer = true;
                    break;
                case EnemyState.Enemy3:
                    FollowPlayer = true;
                    break;
                case EnemyState.Enemy4:
                    PlayerEnter = true;
                    break;
                case EnemyState.Enemy5:
                    FollowPlayer = true;
                    SwordUp = true;
                    break;
                default:
                    FollowPlayer = false;
                    ShootPlayer = false;
                    PlayerEnter = false;
                    break;
            }
        }
    }

    public void EnemyOneController()
    {
        enemyState = EnemyState.Enemy1;
        RegularEnemy = true;
        
        if(FollowPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }
    }

    public void EnemyTwoController()
    {
        enemyState = EnemyState.Enemy2;
        ShooterEnemy = true;

        if(ShootPlayer)
        {
            if(Time.time > ShootTime)
            {
                ShootTime = Time.time + FireRate / 1000;

                GameObject newBullet = Instantiate(Bullet, this.transform.position, this.transform.rotation);
                newBullet.SetActive(true);
                Rigidbody2D rigit = newBullet.GetComponent<Rigidbody2D>();

                if (PlayerIncomeHorizontal)
                {
                    if (Player.position.x > this.transform.position.x)
                    {
                        rigit.transform.position = new Vector2(this.gameObject.transform.position.x + 5, this.gameObject.transform.position.y);
                        ShootBullet(rigit, Vector3.right);
                    }


                    if (Player.position.x < this.transform.position.x)
                    {
                        rigit.transform.position = new Vector2(this.gameObject.transform.position.x - 5, this.gameObject.transform.position.y);
                        ShootBullet(rigit, Vector3.left);

                    }
                }
               

                if(PlayerIncomeVertical)
                {
                    if (Player.position.y > this.transform.position.y)
                    {
                        rigit.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5);
                        ShootBullet(rigit, Vector3.up);
                    }


                    if (Player.position.y < this.transform.position.y)
                    {
                        rigit.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 5);
                        ShootBullet(rigit, Vector3.down);
                    }
                }
            }
        }
    }

    private void ShootBullet(Rigidbody2D rigit, Vector3 vector)
    {
        rigit.AddRelativeForce(vector * BulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void EnemyThreeController()
    {
        enemyState = EnemyState.Enemy3;
        InvisibleEnemy = true;

        if(FollowPlayer)
        {
            Speed = 15;
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }
    }

    public void EnemyFourController()
    {
        enemyState = EnemyState.Enemy4;
        BombEnemy = true;

        if(PlayerEnter)
        {
            SpriteRen.sprite = NewSprite;
        }

        collision = GetComponent<BoxCollider2D>();

        if (BombEnemy && collision.IsTouching(Player.GetComponent<BoxCollider2D>()))
        {
            mainPlayer.HealthAmount = 0;
            Destroy(this.gameObject);
            BombEnemy = false;
        }

        
    }

    public void EnemyFiveController()
    {
        enemyState = EnemyState.Enemy5;
        ShadowEnemy = true;

        if (FollowPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }

        if (SwordUp)
        {
            if(Player.position.x < this.transform.position.x) //&& Counter >= 1)
            {
                EnemySword1.SetActive(true);
                EnemySword2.SetActive(false);
            }
            else if(Player.position.x > this.transform.position.x)// && Counter >= 1)
            {
                EnemySword2.SetActive(true);
                EnemySword1.SetActive(false);
            }
            
        }
    }
}
