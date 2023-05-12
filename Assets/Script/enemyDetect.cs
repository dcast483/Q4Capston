using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyDetect : MonoBehaviour
{
    public string sceneToLoad;
    public bool detects = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //teleports player to attack arena
        if (collision.gameObject.tag == "Player" && detects)
        {
            SceneManager.LoadScene(sceneToLoad);
            detects = false;
        }
    }
}
