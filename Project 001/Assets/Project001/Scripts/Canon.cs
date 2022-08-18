using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    //Script-------
    JoystickPlayerExample joystickPlayerExample;
    //-------------

    [SerializeField] float blust_power;
    [SerializeField] GameObject canon_ball;
    [SerializeField] Transform shoot_point;

    public Transform Target;
    bool isFire = true;

    // Start is called before the first frame update
    void Start()
    {
        joystickPlayerExample = GameObject.Find("Dio").GetComponent<JoystickPlayerExample>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);

        float distance = Target.position.z - shoot_point.position.z;

        if (isFire == true && Mathf.Abs(distance) < 10f && joystickPlayerExample.death == false) //If player death not fire cannonball and if isfire is true
        {
            isFire = false;
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(5);

        if (joystickPlayerExample.death == false) //If player death not fire cannonball
        {
            isFire = true;

            GameObject CreatedCannonball = Instantiate(canon_ball, shoot_point.position, shoot_point.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = shoot_point.transform.up * blust_power;
        }
    }

}//CLASS

