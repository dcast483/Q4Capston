using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public int dmg = 5;
    public int eHp = 30;
    public TurnHandle turnHandle;
    public TextMeshProUGUI Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "Enemy Health: " + eHp.ToString();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //enemies hp and damage taken
        if (collision.gameObject.tag == "bullet")
        {
            eHp -= dmg;
            if(eHp <= 0)
            {
                turnHandle.state = BattleState.Won;
            }
        }
    }
}
