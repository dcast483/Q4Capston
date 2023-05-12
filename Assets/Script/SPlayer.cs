using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SPlayer : MonoBehaviour
{
    //where i start
    private Vector3 startingpos = new Vector3(450, 158, 0);
    public float speed;
    public float Sensitivity;
    private Vector2 MovePos;

    public float MaxX = 582f;
    public float MaxY = 243f;
    public float MinX = 320f;
    public float MinY = 81f;
    //projectile
    public GameObject projectilePrefab;
    public TurnHandle turnHandle;
    public AudioSource audioSource;

    void Start()
    {
        SetHeart();
    }

    public void SetHeart()
    {
        //starting position
        transform.position = startingpos;
        MovePos = startingpos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //player movement
        float horizontal = Input.GetAxis("Horizontal") * Sensitivity;
        float vertical = Input.GetAxis("Vertical") * Sensitivity;

        MovePos.x += horizontal;
        MovePos.y += vertical;

        MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
        MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

        transform.position = Vector2.Lerp(transform.position, MovePos, speed * Time.deltaTime);

       
    }
    private void Update()
    {
        //shoots bullet
        if (turnHandle.state == BattleState.PlayerAtkTurn)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                audioSource.Play();
                turnHandle.state = BattleState.PlayerTurn;

            }
        }
    }
}
