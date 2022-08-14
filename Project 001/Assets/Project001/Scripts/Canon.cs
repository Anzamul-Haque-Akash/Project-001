using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] float blust_power;
    [SerializeField] GameObject canon_ball;
    [SerializeField] Transform shoot_point;

    public Transform Target;
    bool isFire = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);

        float distance = Target.position.z - shoot_point.position.z;

        if (isFire == true && Mathf.Abs(distance) < 20f)
        {
            isFire = false;
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(2);

        isFire = true;

        GameObject CreatedCannonball = Instantiate(canon_ball, shoot_point.position, shoot_point.rotation);
        CreatedCannonball.GetComponent<Rigidbody>().velocity = shoot_point.transform.up * blust_power;
    }

}//CLASS

