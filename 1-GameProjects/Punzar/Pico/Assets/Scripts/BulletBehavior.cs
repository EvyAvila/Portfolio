using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletDirection { Left, Right, Down, Up, Default}

public class BulletBehavior : MonoBehaviour
{
    public float OnScreenDelay = 5f;
    public MainPlayer player;
    public Vector3 Direction; 
    public BulletDirection bulletDirection;

    public float BulletSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, OnScreenDelay);
    }

    private void Update()
    {
        switch(bulletDirection)
        {
            case BulletDirection.Right:
                Direction.x += 1 * BulletSpeed * Time.deltaTime;
                break;
            case BulletDirection.Left:
                Direction.x += -1 * BulletSpeed * Time.deltaTime;
                break;
            case BulletDirection.Up:
                Direction.y += 1 * BulletSpeed * Time.deltaTime;
                break;
            case BulletDirection.Down:
                Direction.y += -1 * BulletSpeed * Time.deltaTime;
                break;

        }
        transform.position = Direction;
    }
   
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("MainPlayer"))
        {
            player.HealthAmount -= 1;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Sword"))
        {
            Destroy(this.gameObject);
        }

    }

}
