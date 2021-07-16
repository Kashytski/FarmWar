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
        Instantiate(Boom, gameObject.transform.position, gameObject.transform.rotation);
        StopCoroutine(Extantion());
        Destroy(gameObject);
    }
}
