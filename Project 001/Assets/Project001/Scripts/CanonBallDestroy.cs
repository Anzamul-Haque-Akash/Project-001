using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Distroy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Distroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}//CLASS
