using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public TurnHandle turnHandle;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //does nothing
        if (turnHandle.state == BattleState.Won)
        {
            audioSource.Play();
        }
    }
}
