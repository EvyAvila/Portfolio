using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperNovaEnemy : Entity
{
    //The transform gets the position of the player so that the enemy may follow
    public Transform Player;

    //A bool to check whether the player has enter the line of sight of the enemy, they
    //may begin to follow
    public bool FollowThePlayer;

    //The enemy gets the battle script to start the fight
    public TurnBasedBattle battle;

    //A public text to display the enemies health during combat
    public Text EnemyHealthText;

    //A private int that sets the specific enemy health amount
    private int SNHEALTH = 50;

    // Start is called before the first frame update
    // It sets the values of each variables such as 
    // health, speed, and text
    void Start()
    {
        
        Health = SNHEALTH;

        MaxHealth = Health;

        FollowThePlayer = false;

        Speed = 2;

        EnemyHealthText.text = "";

        FightPlayer = false;
    }

    // Update is called once per frame
    // A method with a bool paramater to check whether to chase the player or not
    // It also checks the enemies health to make sure they are still alive
    // Finally, the text is displayed if the bool FightPlayer is true and calls
    // a clears the text if the enemy had died
    void Update()
    {
        ChaseThePlayer(FollowThePlayer);
        CheckEnemyHealth();

        DisplayEnemyText(Health, MaxHealth, EnemyHealthText, FightPlayer);

        CheckActive(EnemyHealthText);

    }

    //The bool becomes true when the player enters the trigger point and the tag is matched
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainPlayer"))
        {
            FollowThePlayer = true;
        }
    }

    //Ideally, this is when the player actually touches the enemy it'll prompt the battle sequence to start
    //and set the correct buttons to be displayed for the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainPlayer"))
        {
            //Debug.Log("THE FIGHT BEGINS!");
            FightPlayer = true;

            battle.PlanetFight = true;
            battle.normalAttBtn.gameObject.SetActive(true);
            battle.superNovaAttBtn.gameObject.SetActive(true);
            Speed = 0;
        }
    }

    //The method first checks the condition of the bool. If the condition is true, aka the enemy can 
    //follow the player, than the enemy will move towards the position of the player
    void ChaseThePlayer(bool condition)
    {
        if (condition)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }
    }

    //In the method, when the enemy is in battle, they are dealt with damage
    //from the player. If the health is less than or equal to 0, the enemy dies
    //and the object destories itself. I also plan to have text display the health whenever
    //the enemy and player are in combat.
    void CheckEnemyHealth()
    {
        if (IsDead())
        {
            EnemyHealthText.text = "";
            Health = 0;
            //Debug.Log("Enemy dies >:)");
            battle.SuperNovaFight = false;
            this.gameObject.SetActive(false);
        }

    }

}
