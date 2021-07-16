using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FarmerScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRender;

    [SerializeField] Sprite[] arraySprite;
    [SerializeField] Text counter;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        updateFarmerPosition();        
    }

    void updateFarmerPosition()
    {
        if (transform.position.y > 2.5)
            StartCoroutine(BackToLine_1());

        if (transform.position.y < -2.3)
            StartCoroutine(BackToLine_2());

        if (spriteRender.sprite == arraySprite[0] && transform.position.x < 2.8)
            rigidBody.velocity = new Vector3(4, 0, 0);
        else if (transform.position.x >= 2.8)  spriteRender.sprite = arraySprite[1];

        if (spriteRender.sprite == arraySprite[1] && transform.position.x > -3.2)
            rigidBody.velocity = new Vector3(-4, 0, 0);
        else if (transform.position.x <= -3.2) spriteRender.sprite = arraySprite[0];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boom")
        {
            counter.text = $"{int.Parse(counter.text) + 20}";
            StartCoroutine(Stanlock());
        }
    }

    IEnumerator BackToLine_1()
    {
        yield return new WaitForSecondsRealtime(2f);
        transform.position = new Vector3(-3.2f, 2, -2);
        StopCoroutine(BackToLine_1());
    }

    IEnumerator BackToLine_2()
    {
        yield return new WaitForSecondsRealtime(2f);
        transform.position = new Vector3(2.8f, -1.8f, -2);
        StopCoroutine(BackToLine_2());
    }

    IEnumerator Stanlock()
    {
        if (spriteRender.sprite == arraySprite[0])
            spriteRender.sprite = arraySprite[2];
        else spriteRender.sprite = arraySprite[3];

        yield return new WaitForSecondsRealtime(3f);

        if (spriteRender.sprite == arraySprite[2])
            spriteRender.sprite = arraySprite[0];
        else spriteRender.sprite = arraySprite[1];

        StopCoroutine(Stanlock());
    }
}