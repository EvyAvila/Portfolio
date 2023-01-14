using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This enemy shoots triangle bullets at the player
public class ShooterEnemy : EnemyUnity
{
    //private float BulletSpeed = 600f;
    public GameObject Bullet;

    public BulletBehavior bullet;

    private float FireRate = 2000f;

    private float ShootTime;
    public bool PlayerIncomeHorizontal;
    public bool PlayerIncomeVertical;

    private bool ShootPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Health = 30;
        MaxHealth = Health;
        Speed = 0;
        enemyType = EnemyTypes.Shooty;
        ShootPlayer = false;
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
            ShootPlayer = true;
        }
    }

    public override void Controller()
    {
        base.Controller();

        if(ShootPlayer)
        {
            if (Time.time > ShootTime)
            {
                ShootTime = Time.time + FireRate / 1000;

                #region Note
                /*
                    This sets the very first bullet location to the enemy. The reason for this is because when the bullet is created for the
                    first time, it's position it as the center or 0,0,0.  bullet.Direction = this.transform.position is mainly for the first bullet
                    as for the rest of the bullets work properly
                */
                #endregion
                bullet.Direction = this.transform.position;

                GameObject newBullet = Instantiate(Bullet, this.transform.position, this.transform.rotation);

                bullet.Direction = newBullet.transform.position;

                ShootPlayerHorizontal(newBullet);
                ShootPlayerVertical(newBullet);
            }
        }
    }

    private void ShootPlayerVertical(GameObject newBullet)
    {
        if (PlayerIncomeVertical) //In the inspector, the person has the option to select which direction the bullet will be shot at
        {
            if (Player.position.y > this.transform.position.y)
            {
                newBullet.SetActive(true);

                bullet.bulletDirection = BulletDirection.Up;

                newBullet.transform.position = bullet.Direction;
            }


            if (Player.position.y < this.transform.position.y)
            {
                newBullet.SetActive(true);

                bullet.bulletDirection = BulletDirection.Down;

                newBullet.transform.position = bullet.Direction;
            }
        }
    }

    private void ShootPlayerHorizontal(GameObject newBullet)
    {
        if (PlayerIncomeHorizontal) //In the inspector, the person has the option to select which direction the bullet will be shot at
        {
            if (Player.position.x > this.transform.position.x)
            {
                newBullet.SetActive(true);

                bullet.bulletDirection = BulletDirection.Right;

                newBullet.transform.position = bullet.Direction;
            }


            if (Player.position.x < this.transform.position.x)
            {
                newBullet.SetActive(true);

                bullet.bulletDirection = BulletDirection.Left;

                newBullet.transform.position = bullet.Direction;
            }
        }
    }
}
