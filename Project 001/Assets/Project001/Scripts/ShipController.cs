using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //Scripts------------------
    GameManager gameManager;
    //-------------------------

    Rigidbody m_Rigidbody;
    float m_Speed;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = transform.forward * m_Speed;

        /*
        if (transform.position.z >= 0f && transform.position.z <= 1f)
        {
            gameManager.GroundActive(0);
        }
        if (transform.position.z >= 200f && transform.position.z <= 201f)
        {
            gameManager.GroundActive(1);
        }
        */
    }
}//CLASS