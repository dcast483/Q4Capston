using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnHandle : MonoBehaviour
{
    public bool FinishedTurn;

    public int AttackAmounts;
    void Start()
    {
        //which attack to use
        FinishedTurn = false;

        int atkNumb = Random.Range(0, AttackAmounts);
        GetComponent<Animator>().SetInteger("AtkDex", atkNumb);
    }

    public void AtkDone()
    {
        FinishedTurn = true;
    }

}
