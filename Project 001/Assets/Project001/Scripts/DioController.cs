using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioController : MonoBehaviour
{
    public Animator anim;

    [SerializeField] float dio_speed;
    Vector3 Vec;
    // Start is called before the first frame update  
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CanonBall")
        {
            Debug.Log("Player Death!!");
        }
    }

    // Update is called once per frame  
    void Update()
    {
        Vec = transform.localPosition;
        Vec.x += Input.GetAxisRaw("Horizontal") * Time.deltaTime * dio_speed;
        Vec.z += Input.GetAxisRaw("Vertical") * Time.deltaTime * dio_speed;
        transform.localPosition = Vec;


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isIdle", true);
        }
        
    }
}//CLASS

