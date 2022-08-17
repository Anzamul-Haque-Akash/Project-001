using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    [SerializeField] Animator anim; //Dio Animator

    public bool death = false; //Dio Death or not

    public float speed; //Dio Speed
    public FloatingJoystick floatingJoystick; //DIo FloationJoystic
    public Rigidbody rb; //DIo rigidbody

    [SerializeField] GameObject WaterSplashPS; //Water Splash Partical System


    [SerializeField] GameObject[] DioMesh; //Dio mesh

    private void OnTriggerEnter(Collider other) //On trigger enter function
    {
        if (other.gameObject.tag == "CanonBall")
        {
            Debug.Log("Player Death!!");

            Destroy(other.gameObject); //Destroy Hit Cannonball

            death = true;
        }
        if(other.gameObject.tag == "Stop") //Player stop in water
        {
            Debug.Log("Player Stop!!");

            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            DioMesh[0].SetActive(false);
            DioMesh[1].SetActive(false);

            WaterSplashPS.SetActive(true); //Water Splash
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
        }
    }
}//CLASS