using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BushScript : MonoBehaviour
{
    [SerializeField] Text counter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boom")
        {
            counter.text = $"{int.Parse(counter.text) + 5}";
            Destroy(gameObject);
        }
    }
}
