using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int xVelocity = 8;
    int yVelocity = 8;
    float verticalInput;
    float horizontInput;

    [SerializeField] Sprite[] arraySprites;
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject steak_1;
    [SerializeField] GameObject steak_2;
    [SerializeField] GameObject gameOver;
    private float timeDelay = 1.0f;
    private float timeStamp;

    private SpriteRenderer spriteRender;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        updatePlayerPosition();
    }

    private void updatePlayerPosition()
    {
        horizontInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Time.time >= timeStamp && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bomb, transform.position + new Vector3(0, 0, -1), transform.rotation);
            timeStamp = Time.time + timeDelay;
        }

        if (horizontInput < 0)
        {
            rigidBody.velocity = new Vector3(-xVelocity, 0, 0);
            spriteRender.sprite = arraySprites[1];
            boxCollider.size = new Vector2(5, 3);
        }

        else if (horizontInput > 0)
        { 
            rigidBody.velocity = new Vector3(xVelocity, 0, 0);
            spriteRender.sprite = arraySprites[0];
            boxCollider.size = new Vector2(5, 3);
        }

        if (verticalInput < 0)
        {
            rigidBody.velocity = new Vector3(-1, -yVelocity, 0);
            spriteRender.sprite = arraySprites[2];
            boxCollider.size = new Vector2(3, 5);
        }

        else if (verticalInput > 0)
        {
            rigidBody.velocity = new Vector3(1, yVelocity, 0);
            spriteRender.sprite = arraySprites[3];
            boxCollider.size = new Vector2(3, 5);   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boom")
        {
            Instantiate(steak_1, transform.position, transform.rotation);
            DestroyPig();
        }
        else if (collision.gameObject.tag == "enemy")
        {
            Instantiate(steak_2, transform.position, transform.rotation);
            DestroyPig();
        }
    }

     void DestroyPig()
    {
        Instantiate(gameOver);
        Destroy(gameObject);
    }
}
