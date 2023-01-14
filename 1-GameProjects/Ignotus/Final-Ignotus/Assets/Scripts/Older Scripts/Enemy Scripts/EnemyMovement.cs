using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//NO LONGER USING, JUST AS REFERENCE
public class EnemyMovement : MonoBehaviour
{
    //The float is the speed in which the enemy travels
    public float EnemySpeed;

    public float DefaultEnemySpeed;

    //The transform gets the position of the player so that the enemy may follow
    public Transform Theplayer;

    //A bool to check whether the player has enter the line of sight of the enemy, they
    //may begin to follow
    private bool FollowThePlayer;

    private EnemyHealth enemyHealth;

    // Start is called before the first frame update
    // It sets the bool to false as the enemy has not encounter the player
    void Start()
    {
        FollowThePlayer = false;
        enemyHealth = GetComponent<EnemyHealth>();
        DefaultEnemySpeed = EnemySpeed;
    }

    // Update is called once per frame
    // A method with a bool paramater to check whether to chase the player or not
    void Update()
    {
        ChaseThePlayer(FollowThePlayer);
    }

    //The bool becomes true when the player enters the trigger point and the tag is matched
    private void OnTriggerEnter(Collider other)      
    {
        if(other.gameObject.tag == "MainPlayer")
        {
            FollowThePlayer = true;
        }
    }

    //public GameController gameController;

    //Ideally, this is when the player actually touches the enemy it'll prompt the battle sequence to start
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MainPlayer")
        {
            Debug.Log("THE FIGHT BEGINS!");

            EnemySpeed = 0;

            switch(enemyHealth.TypeOfEnemy)
            {
                case EnemyState.BlackHole:
                    BlackHoleEnemy();
                    break;
                case EnemyState.Planet:
                    PlanetEnemy();
                    break;
                case EnemyState.SuperNova:
                    SuperNovaEnemy();
                    break;
            }
            SetActiveTurnGame();

            
            
        }
        
    }

    //The method first checks the condition of the bool. If the condition is true, aka the enemy can 
    //follow the player, than the enemy will move towards the position of the player
    void ChaseThePlayer(bool condition)
    {
        if(condition)
        {
            transform.position = Vector3.MoveTowards(transform.position, Theplayer.position, EnemySpeed * Time.deltaTime);
        }
        
    }

    void SetActiveTurnGame()
    {
        //gameController.playerHealth.gameObject.SetActive(true);
        //gameController.EnemyHealth.gameObject.SetActive(true);
        //gameController.normalAttBtn.gameObject.SetActive(true);
        
    }

    void BlackHoleEnemy()
    {
        //gameController.blackHoleAttBtn.gameObject.SetActive(true);
    }

    void PlanetEnemy()
    {
        //gameController.planetAttBtn.gameObject.SetActive(true);
    }

    void SuperNovaEnemy()
    {
        //gameController.superNovaAttBtn.gameObject.SetActive(true);
    }



}
