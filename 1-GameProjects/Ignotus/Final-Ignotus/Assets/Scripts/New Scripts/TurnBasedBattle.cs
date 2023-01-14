using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class will need some fixing and mainly just works on one enemy at the moment.

public class TurnBasedBattle : MonoBehaviour
{
    //Received help from Marc Temkin

    //A public mainPlayer that gets the object that contains 
    //the MainPlayer script
    public MainPlayer mainPlayer;

    //A public Entity called Enemy that checks what each enemy
    //is fighting. There seems to be an issue where after the first fight with the player, the rest of the
    //enemies health are lower than they should. I didn't have enough time to find the issue to fix it.
    public Entity Enemy = null;


    //A public button that will set its interactivity when it is the player's turn or not
    //There are four buttons for each attack the player can use
    [SerializeField] public Button normalAttBtn = null; // A general attack
    [SerializeField] public Button blackHoleAttBtn = null; //A special attack for BlakHole enemy types
    [SerializeField] public Button planetAttBtn = null; //A special attack for Planet enemy types
    [SerializeField] public Button superNovaAttBtn = null; //A special attack for SuperNova enemy types

    //A bool to check if it is the player's turn to attack
    private bool IsPlayerTurn = true;

    //A public float called Lag to give time for each turn
    public float Lag = .1f;

    //A public bool that checks which enemy is currently fighting
    public bool BlackHoleFight;
    public bool PlanetFight;
    public bool SuperNovaFight;

    // Start is called before the first frame update
    // Sets the start battle to false and diactivates the buttons so
    // that they aren't always present
    void Start()
    {
        DeactivateButtonsPlayerUI(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //A void that will be mainly used for the player and enemy. 
    //since the main player and enemies are entities, the script inherit from Entity.
    //If the target is the specific enemy or the player, their health will descrease based on the damage
    //amount they received. It also checks the condition on which enemy is fighting to start the BattleSequence
    private void Attacking(Entity target, int damage)
    {
        if (target is BlackHoleEnemy)
        {
            if (target == Enemy)
            {
                Enemy.GetComponent<BlackHoleEnemy>().Health -= damage;
            }

        }
        else if (target is PlanetEnemy)
        {
            if (target == Enemy)
            {
                Enemy.GetComponent<PlanetEnemy>().Health -= damage;
            }
        }
        else if (target is SuperNovaEnemy)
        {
            if (target == Enemy)
            {
                Enemy.GetComponent<SuperNovaEnemy>().Health -= damage;
            }
        }
        else if (target is MainPlayer)
        {
            mainPlayer.Health -= damage;
        }

        CurrentlyFighting();

    }

    //A void to check who is fighting to be able to attack the player instead of everyone
    private void CurrentlyFighting()
    {
        if (BlackHoleFight)
        {
            StartCoroutine(BattleSequence());
        }
        else if (PlanetFight)
        {
            StartCoroutine(BattleSequence());
        }
        else if (SuperNovaFight)
        {
            StartCoroutine(BattleSequence());
        }
    }

    //A void for the Canvas button that will occur for when the player
    //presses it. This method is a general attack button
    public void RegularButtonAttack()
    {
        if(Enemy.CompareTag("BlackHole"))
        {
            Attacking(Enemy, 2);
        }
        else if(Enemy.CompareTag("Planet"))
        {
            Attacking(Enemy, 2);
        }
        else if(Enemy.CompareTag("SuperNova"))
        {
            Attacking(Enemy, 2);
        }
       
    }

    //A void for the Canvas button that will occur for when the player
    //presses it. This method mainly for BlackHole enemies that deal more damage
    public void BlackHoleButtonAttact()
    {
        Attacking(Enemy, 10);
    }

    //A void for the Canvas button that will occur for when the player
    //presses it. This method mainly for Planet enemies that deal more damage
    public void PlanetButtonAttact()
    {
        Attacking(Enemy, 12);
    }

    //A void for the Canvas button that will occur for when the player
    //presses it. This method mainly for SuperNova enemies that deal more damage
    public void SuperNovaButtonAttact()
    {
        Attacking(Enemy, 14);
    }

    //This is where the main battle occurs. The bool IsPlayerTurn 
    //set to true at the start, so the player will always go first. Then the condition is set to the 
    //opposite to allow the enemy to attack. Whenever it's the enemies turn, the buttons are disables
    //to prevent the player from attacking again. It first checks if the enemies health is greater than 0,
    //then they can attack back. If so, then the buttons are turned off from the UI. Afterwards it returns 
    //back to the player's turn that is randomized to get a special attack for the specific enemy
    IEnumerator BattleSequence()
    {
        IsPlayerTurn = !IsPlayerTurn;
        if (!IsPlayerTurn) //Enemy turn
        {
            DisableInteractive(false);

            if (BlackHoleFight)
            {
                PlanetFight = false;
                SuperNovaFight = false;

                if (Enemy.Health > 0)
                {
                    StartCoroutine(WaitTurn());
                }
                else if (Enemy.IsDead())
                {
                    DeactivateBattleUI(true, false);

                    Enemy.Health = 0;

                }
            }
            else if (PlanetFight)
            {
                BlackHoleFight = false;
                SuperNovaFight = false;

                if (Enemy.Health > 0)
                {
                    StartCoroutine(WaitTurn());
                }
                else if (Enemy.IsDead())
                {
                    DeactivateBattleUI(true, false);

                    Enemy.Health = 0;
                }
            }
            else if (SuperNovaFight)
            {
                BlackHoleFight = false;
                PlanetFight = false;

                if (Enemy.Health > 0)
                {
                    StartCoroutine(WaitTurn());
                }
                else if (Enemy.IsDead())
                {
                    DeactivateBattleUI(true, false);

                    Enemy.Health = 0;
                }
            }

            yield return new WaitForSeconds(Lag);

        }
        else //Player's turn
        {
            normalAttBtn.interactable = true;

            int rand = 0;
            rand = Random.Range(1, 3);

            if (rand == 1)
            {
                SpecialAttackButtonCondition(true);
            }
            else
            {
                SpecialAttackButtonCondition(false);
            }

            if(mainPlayer.IsDead())
            {
                DeactivateButtonsPlayerUI(false);
            }

            yield return new WaitForSeconds(Lag);
        }
    }

    //A private method extracted to prevent long repeated code. It's purpose is to disable the entire interactable of 
    //the buttons.
    private void DisableInteractive(bool condition)
    {
        normalAttBtn.interactable = condition;
        blackHoleAttBtn.interactable = condition;
        planetAttBtn.interactable = condition;
        superNovaAttBtn.interactable = condition;
    }

    //A private method extracted to prevent long repeated code. The purpose is to disable the buttons that player uses when the battle is over
    //as there is no point in keeping the buttons active
    private void DeactivateButtonsPlayerUI(bool condition)
    {
        normalAttBtn.gameObject.SetActive(condition);
        blackHoleAttBtn.gameObject.SetActive(condition);
        planetAttBtn.gameObject.SetActive(condition);
        superNovaAttBtn.gameObject.SetActive(condition);
    }

    //A private method extracted to prevent long repeated code. It's purpose is for the random occurence of making the button interactive 
    //for the player if the number is 1 or disable if the number is other.
    private void SpecialAttackButtonCondition(bool condition)
    {
        blackHoleAttBtn.interactable = condition;
        planetAttBtn.interactable = condition;
        superNovaAttBtn.interactable = condition;
    }

    //A private method extracted to prevent long repeated code. It's main purpose is to get rid of everything that is display in the UI from 
    //when checking if the enemy is dead.
    private void DeactivateBattleUI(bool conditionTrue, bool conditionFalse)
    {
        IsPlayerTurn = conditionTrue;
        normalAttBtn.interactable = conditionTrue;

        DeactivateButtonsPlayerUI(conditionFalse);

        mainPlayer.InBattle = conditionFalse;
    }


    //The IEnumerator returns a set time before the enemy attacks
    //So that it feels more natural than a sudden attack
    private IEnumerator WaitTurn()
    {
        yield return new WaitForSeconds(3);

        int random = 0;
        random = Random.Range(1, 2);

        if (random == 1)
        {
            Attacking(mainPlayer, 1);
        }
        else
        {
            Attacking(mainPlayer, 2);
        }

        StopCoroutine(WaitTurn());
    }
}
