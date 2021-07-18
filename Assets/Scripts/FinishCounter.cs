using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishCounter : MonoBehaviour
{
    [SerializeField] Text counter;
    [SerializeField] GameObject stone;

    private void Update()
    {
        //Условие открытия выхода
        int counterInt = int.Parse(counter.text);
        if (counterInt > 219)
            stone.SetActive(false);
    }
}
