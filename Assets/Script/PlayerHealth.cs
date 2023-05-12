using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp;
    public int MaxHp;
    public TurnHandle turnHandle;

    public void TakeDamage(int Dmg)
    {
        //damage taken
        hp -= Dmg;

        if(hp <=0 )
        {
            Debug.Log("GameOver!");
            turnHandle.state = BattleState.Lost;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
