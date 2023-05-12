using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class eHp : MonoBehaviour
{
    public TextMeshProUGUI Health;
    public EnemyHp EnemyHp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //eney health
        Health.text = "Enemy Health: " + EnemyHp.eHp.ToString();
    }
}
