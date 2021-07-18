using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] GameObject gameComplete;
    [SerializeField] GameObject restartButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Условие окончания игры
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Instantiate(gameComplete);
            restartButton.SetActive(true);
        }
    }
}
