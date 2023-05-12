using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pHp : MonoBehaviour
{
    public TextMeshProUGUI PHealth;
    public PlayerHealth PlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //players hp displayed
        PHealth.text = "Health: " + PlayerHealth.hp.ToString();
    }
}
