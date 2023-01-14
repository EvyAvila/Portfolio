using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the Shadow Enemy
public class EnemySword : MonoBehaviour
{
    public MainPlayer player;
    public ShadowEnemy shadowEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MainPlayer"))
        {
            player.HealthAmount -= 2;
        }

        if(collision.gameObject.CompareTag("Sword"))
        {
            gameObject.SetActive(false);
            shadowEnemy.SwordUp = false;
        }
    }
}
