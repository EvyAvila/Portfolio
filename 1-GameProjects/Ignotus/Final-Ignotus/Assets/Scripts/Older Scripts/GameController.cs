using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //NOT USING, JUST AS REFERENCE
    /*
    [SerializeField] private GameObject MainPlayer = null;
    [SerializeField] public GameObject Enemy = null;
    [SerializeField] public Slider playerHealth = null;
    [SerializeField] public Slider EnemyHealth = null;

    [SerializeField] public Button normalAttBtn = null;
    [SerializeField] public Button blackHoleAttBtn = null;
    [SerializeField] public Button planetAttBtn = null;
    [SerializeField] public Button superNovaAttBtn = null;

    [SerializeField] private GameObject StarHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.gameObject.SetActive(false);
        EnemyHealth.gameObject.SetActive(false);
        normalAttBtn.gameObject.SetActive(false);
        blackHoleAttBtn.gameObject.SetActive(false);
        planetAttBtn.gameObject.SetActive(false);
        superNovaAttBtn.gameObject.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
        //playerHealth.value = characterHealth.PlayerHealth;
        
    }

    [SerializeField] private CharacterHealth characterHealth;
    [SerializeField] private EnemyHealth enemyHealth;

    private bool IsPlayerTurn = true;

    private void Attack(GameObject target, int damage)//, EnemyState enemy)
    {
            if(target == Enemy)// && Enemy.GetComponent<EnemyState>() == enemy)
            {
                EnemyHealth.value -= damage;
            }
            else
            {
              
                playerHealth.value -= damage;
            }

        ChangeTurn();
    }


    public void RegularButtonAttack()
    {
        //if(Enemy.GetComponent<EnemyHealth>().TypeOfEnemy == EnemyState.BlackHole)
        Attack(Enemy, 2);//, EnemyState.BlackHole);

        //if (Enemy.GetComponent<EnemyHealth>().TypeOfEnemy == EnemyState.Planet)
        //Attack(Enemy, 2);// EnemyState.Planet);

        //if (Enemy.GetComponent<EnemyHealth>().TypeOfEnemy == EnemyState.SuperNova)
        //Attack(Enemy, 2);// EnemyState.SuperNova);
    }

    public void BlackHoleButtonAttact()
    {
        Attack(Enemy, 10);// EnemyState.BlackHole);
    }

    public void PlanetButtonAttact()
    {
        Attack(Enemy, 12);//, EnemyState.Planet);
    }

    public void SuperNovaButtonAttact()
    {
        Attack(Enemy, 14);//, EnemyState.SuperNova);
    }
    
    private void ChangeTurn()
    {
        IsPlayerTurn = !IsPlayerTurn;

        if(!IsPlayerTurn)
        {
            normalAttBtn.interactable = false;
            blackHoleAttBtn.interactable = false;
            planetAttBtn.interactable = false;
            superNovaAttBtn.interactable = false;

            if(EnemyHealth.value > 0)
            {
                StartCoroutine(EnemyTurn());
            }
            else
            {
                IsPlayerTurn = true;
                normalAttBtn.interactable = true;
                Enemy.SetActive(false);
                
                EnemyHealth.value = float.MaxValue;

                //Start();


                playerHealth.gameObject.SetActive(false);
                EnemyHealth.gameObject.SetActive(false);
                normalAttBtn.gameObject.SetActive(false);
                blackHoleAttBtn.gameObject.SetActive(false);
                planetAttBtn.gameObject.SetActive(false);
                superNovaAttBtn.gameObject.SetActive(false);
            }

        }
        else
        {
            normalAttBtn.interactable = true;

            int rand = 0;
            rand = Random.Range(1, 3);

            if (rand == 1)
            {
                blackHoleAttBtn.interactable = true;
                planetAttBtn.interactable = true;
                superNovaAttBtn.interactable = true;
            }
            else
            {
                blackHoleAttBtn.interactable = false;
                planetAttBtn.interactable = false;
                superNovaAttBtn.interactable = false;
            }

            
        }
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(3);

        int random = 0;
        random = Random.Range(1, 2);

        if(random == 1)
        {
            Attack(MainPlayer, 1);
        }
        else
        {
            Attack(MainPlayer, 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MainPlayer")
        {
            Enemy.SetActive(true);
            Enemy.transform.position = new Vector3(2, -0.16f, 10);
        }
    }
    */
}
