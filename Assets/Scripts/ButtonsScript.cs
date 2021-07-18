using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;

    [SerializeField] Sprite[] arraySprites;
    [SerializeField] GameObject bomb;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    //Биндинг созданных кнопок для сенсорного управления
    public void ButtonW()
    {
        rigidBody.velocity = new Vector3(17, 136, 0);
        spriteRender.sprite = arraySprites[3];
        boxCollider.size = new Vector2(3, 5);
    }

    public void ButtonS()
    {
        rigidBody.velocity = new Vector3(-17, -136, 0);
        spriteRender.sprite = arraySprites[2];
        boxCollider.size = new Vector2(3, 5);
    }

    public void ButtonD()
    {
        rigidBody.velocity = new Vector3(120, 0, 0);
        spriteRender.sprite = arraySprites[0];
        boxCollider.size = new Vector2(5, 3);
    }

    public void ButtonA()
    {
        rigidBody.velocity = new Vector3(-120, 0, 0);
        spriteRender.sprite = arraySprites[1];
        boxCollider.size = new Vector2(5, 3);
    }

    public void ButtonB()
    {
        Instantiate(bomb, transform.position + new Vector3(0, 0, -1), transform.rotation);
    }
}
