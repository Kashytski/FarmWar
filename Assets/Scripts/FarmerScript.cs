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
        //???????? ? ??????????? ?? ???????
        if (spriteRender.sprite == arraySprite[0])
            rigidBody.velocity = new Vector3(4, 0, 0);

        if (spriteRender.sprite == arraySprite[1])
            rigidBody.velocity = new Vector3(-4, 0, 0); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //??????? ?? ???? ????????
        if (collision.gameObject.tag == "boom")
        {
            counter.text = $"{int.Parse(counter.text) + 20}";
            StartCoroutine(Stanlock());
        }

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "boom")
        {
            if (spriteRender.sprite == arraySprite[0])
                spriteRender.sprite = arraySprite[1];
            else spriteRender.sprite = arraySprite[0];
        }
    }

    IEnumerator Stanlock()
    {
        //??????????? ? ??????????? ??????? ? ????????? ?? ?????
        if (name == "farmer_1")
            transform.position = new Vector3(-2.9f, 1.9f, -2);
        else
            transform.position = new Vector3(2.5f, -1.9f, -2);

        if (spriteRender.sprite == arraySprite[0])
        {
            spriteRender.sprite = arraySprite[2];
            yield return new WaitForSecondsRealtime(3f);
            spriteRender.sprite = arraySprite[0];
        }
        else
        {
            spriteRender.sprite = arraySprite[3];
            yield return new WaitForSecondsRealtime(3f);
            spriteRender.sprite = arraySprite[1];
        }        

        StopCoroutine(Stanlock());
    }
}