using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] GameObject Boom;
    void Start()
    {
        StartCoroutine(Extantion());
    }

    IEnumerator Extantion()
    {
        yield return new WaitForSecondsRealtime(2);
        Instantiate(Boom, transform.position, transform.rotation);
        StopCoroutine(Extantion());
        Destroy(gameObject);
    }
}
