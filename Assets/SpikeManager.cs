using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public List<GameObject> plates = new List<GameObject>();
    public List<StartRoom> rooms = new List<StartRoom>();
    public List<bool> pressed;
    public float press = 1f;
    public bool va;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //checks if pressure plates are pressed
        foreach (GameObject i in plates)
        {
            if (i.GetComponent<StartRoom>().pressed == true)
            {
                press++;
            }
        }

        if (press == 3)
        {
            Destroy(GameObject.FindWithTag("spike"));
        }
        else
        {
            press = 0;
        }
    }
}
