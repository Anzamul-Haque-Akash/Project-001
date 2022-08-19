using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{

    //Scrip-----------------------
    ShipController shipController;
    GameManager gameManager;
    //----------------------------

    [SerializeField] Animator anim; //Dio Animator

    public bool death = false; //Dio Death or not
    public bool attacking = true; //Dio attacking or not

    public float speed; //Dio Speed
    public FloatingJoystick floatingJoystick; //DIo FloationJoystic
    public Rigidbody rb; //DIo rigidbody

    [SerializeField] GameObject WaterSplashPS; //Water Splash Partical System

    [SerializeField] GameObject AttackStartPosition; // Dragon attack start position

    [SerializeField] GameObject[] DioMesh; //Dio mesh

    //Start Function
    private void Start()
    {
        shipController = GameObject.Find("Ship").GetComponent<ShipController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) //On trigger enter function
    {
        if (other.gameObject.tag == "CanonBall")
        {
            Destroy(other.gameObject); //Destroy Hit Cannonball

            death = true;
        }
        if(other.gameObject.tag == "Stop") //Player stop in water
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            DioMesh[0].SetActive(false);
            DioMesh[1].SetActive(false);

            WaterSplashPS.SetActive(true); //Water Splash
        }
    }

    private void OnTriggerStay(Collider other) //On trigger stay function
    {
        if (other.gameObject.tag == "Attacking Area") //Ship Attacking area
        {
            Debug.Log("Dio in attacking area.");

            if (attacking == true)
            {
                attacking = false;
                StartCoroutine(Wait(1f));
            }
        }
    }


    public void FixedUpdate()
    {
        if (death == false) //Not death can move
        {
            if (floatingJoystick.Vertical != 0 || floatingJoystick.Horizontal != 0) //Fly animation
            {
                rb.constraints = RigidbodyConstraints.None;

                Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
                rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

                anim.SetBool("isIdle", false);
            }
            else //Idle Animation
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;

                anim.SetBool("isIdle", true);
            }
        }
        else if(anim.GetBool("isDeath") == false) //Detah animation
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isDeath", true);

            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;

            StartCoroutine(GameOver()); //Game Over
        }
    }


    IEnumerator Wait(float t) //Unity Wait for N second function | Dio get attacking
    {
        AttackStartPosition.SetActive(true);

        yield return new WaitForSeconds(t);

        shipController.reduceShieHeath(); //Ship health reduce

        AttackStartPosition.SetActive(false);

        yield return new WaitForSeconds(2f);

        attacking = true;
    }
    IEnumerator GameOver() //$ seceond with for game over
    {
        yield return new WaitForSeconds(4);

        gameManager.EndGame(); //End Game scene
    }


}//CLASS