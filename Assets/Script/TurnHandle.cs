using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState
{
    Start,
    PlayerTurn,
    PlayerAtkTurn,
    EnemyTurn,
    FinishedTurn,
    Won,
    Lost
}
public class TurnHandle : MonoBehaviour
{
    public BattleState state;
    //each enemy
    public EnemyProfile[] EnemiesInBattle;
    private bool enemyActed;
    private GameObject[] EnemyAtks;
    public string sceneToLoad;
    public string sceneToLoads;
    public AudioSource audioSource;
    
    public GameObject playerUi;
    public SPlayer PlayerSword;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        enemyActed = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BattleState.Start)
        {
            //set up lvl
            playerUi.SetActive(true);
            state = BattleState.PlayerAtkTurn;
        }
        if (state == BattleState.Lost)
        {
            //sets you back when lose
            Debug.Log("GameOver!");
            playerUi.SetActive(false);
            SceneManager.LoadScene(sceneToLoad);
        }
        if (state == BattleState.PlayerAtkTurn)
        {
            playerUi.SetActive(true);
        }
        else if (state == BattleState.EnemyTurn)
        {
            if (EnemiesInBattle.Length <= 0)
            {
                //finish enemy turn
               EnemyFinishedTurn();
            }
            else
            {
                if (!enemyActed)
                {
                    PlayerSword.gameObject.SetActive(true);
                    PlayerSword.SetHeart();

                    foreach(EnemyProfile emy in EnemiesInBattle)
                    {
                        int AtkNumb = Random.Range(0, emy.EnemiesAttacks.Length);

                        Instantiate(emy.EnemiesAttacks[AtkNumb], Vector3.zero, Quaternion.identity);
                    }

                    //check if attacks are done
                    EnemyAtks = GameObject.FindGameObjectsWithTag("enemy");
                    enemyActed = true;
                }
                else
                {
                    //enemy finish turn
                    bool enemyfin = true;
                    foreach (GameObject emy in EnemyAtks)
                    {
                        if (!emy.GetComponent<EnemyTurnHandle>().FinishedTurn)
                        {
                            enemyfin = false;
                        }
                    }

                    if(enemyfin)
                    {
                        EnemyFinishedTurn();
                    }
                }
            }
        }
        else if (state == BattleState.FinishedTurn)
        {

            //check player is alive
            if (PlayerSword.GetComponent<PlayerHealth>().hp < 0)
            {
                state = BattleState.Lost;
                PlayerSword.gameObject.SetActive(false);
            }
            else
            {
                state = BattleState.Start;
            }
        }
        if(state == BattleState.Won)
        {
            StartCoroutine(HandleIt());
            
        }
    }
    public void PlayerAct()
    {
        playerfinishTurn();
    }

    void playerfinishTurn()
    {
        //when player turn is over
        playerUi.SetActive(false);
        state = BattleState.EnemyTurn;
    }

    void EnemyFinishedTurn()
    {
        //destroy all attacks
        foreach(GameObject obj in EnemyAtks)
        {
            Destroy(obj);
        }
        enemyActed = false;
        state = BattleState.FinishedTurn;
    }
    private IEnumerator HandleIt()
    {
        //ends level
        playerUi.SetActive(false);
        audioSource.Play();
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneToLoads);
    }
}
