using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    //script--------
    GameManager gameManager;
    //--------------

    Rigidbody m_Rigidbody; //Ship RB
    float m_Speed; //Ship Speed

    int shipHealth = 10;
    [SerializeField] GameObject[] shipHealthUI; //Ship Health

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
        m_Rigidbody.velocity = transform.forward * m_Speed; //Ship Move
    }

    public void reduceShieHeath() //reduce ship heath by Dio Attack
    {
        if(shipHealth >= 0)
        {
            shipHealthUI[shipHealth].SetActive(false);
        }

        shipHealth--;

        if(shipHealth == -1)
        {
            Debug.Log("Ship distroy");
            gameManager.EndGame(); //End Game scene
        }
    }
}//CLASS