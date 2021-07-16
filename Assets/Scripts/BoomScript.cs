using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(2);
        StopCoroutine(Boom());
        Destroy(gameObject);
    }
}
