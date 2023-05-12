//Daniel Castillo
//5/12/2023
//Q4 Capstone

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerM : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    public Animator myAnim;
    public float horizontalInput;
    public float verticalInput;
    public string sceneToLoad;
    public GameObject cam;
    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //player movement and animation

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * 4 * Time.deltaTime;
            m_SpriteRenderer.flipX = true;
            myAnim.Play("move");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * 4 * Time.deltaTime;
            m_SpriteRenderer.flipX = false;
            myAnim.Play("move");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * 4 * Time.deltaTime;
            myAnim.Play("move");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * 4 * Time.deltaTime;
            myAnim.Play("move");
        }
        if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.DownArrow) == false && Input.GetKey(KeyCode.UpArrow) == false)
        {
            myAnim.Play("idol");
        }


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //teleports and gun
        if (collision.gameObject.tag == "tp")
        {
            transform.position = new Vector3(14, -1, 0);
            cam.transform.position = new Vector3(23.25f, 0, -10);
        }
        if(collision.gameObject.tag == "tp1")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        if(collision.gameObject.tag =="gun")
        {
            Destroy(gun);
        }
    }



}
