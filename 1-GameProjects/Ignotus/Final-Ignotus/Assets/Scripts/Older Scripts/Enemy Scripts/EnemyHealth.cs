using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NO LONGER USING, JUST AS REFERENCE
public enum EnemyState { BlackHole, Planet, SuperNova }

public class EnemyHealth : MonoBehaviour
{
    //An int that holds the health of the enemy that will change whenever it takes damage
    public int TheEnemyHealth;

    //A property that contains the total amount of health that is set from the variable TheEnemyHealth 
    public int EnemyTotalHealth { get; private set; }

    public EnemyState TypeOfEnemy;
    
    // Start is called before the first frame update
    //The total health is set from the enemy health, which can be set from the inspector
    void Start()
    {
        EnemyTotalHealth = TheEnemyHealth;

        switch(TypeOfEnemy)
        {
            case EnemyState.BlackHole:
                TheEnemyHealth = 30;
                EnemyTotalHealth = TheEnemyHealth;
                break;
            case EnemyState.Planet:
                TheEnemyHealth = 25;
                EnemyTotalHealth = TheEnemyHealth;
                break;
            case EnemyState.SuperNova:
                TheEnemyHealth = 45;
                EnemyTotalHealth = TheEnemyHealth;
                break;
        }
    }

    // Update is called once per frame
    // It only contains a method for checking the enemies health
    void Update()
    {
        CheckEnemyHealth();
    }

    //In the method, when the enemy is in battle, they are dealt with damage
    //from the player. If the health is less than or equal to 0, the enemy dies
    //and the object destories itself. I also plan to have text display the health whenever
    //the enemy and player are in combat.
    void CheckEnemyHealth()
    {
        if(TheEnemyHealth <= 0)
        {
            TheEnemyHealth = 0;
            Debug.Log("Enemy dies >:)");
            //Destroy(this);
            //this.gameObject.SetActive(false);
        }
        
        //Method to display text
    }
}
