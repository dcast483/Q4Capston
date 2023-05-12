using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartRoom : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public bool pressed = false;
    public AudioSource audioSource;
    public float vol = 0.5f;
    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
    // Start is called before the first frame update

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void Update()
    {

    }

    private void FixedUpdate()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //makes pressure plate change sprite
        if (collision.gameObject.tag == "Player")
        {
            ChangeSprite(newSprite);
            GetComponent<BoxCollider2D>().enabled = false;
            pressed = true;
            audioSource.Play();
        }
    }

}
