using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    float speed;
    float XDirection, YDirection;
    public Vector3 desirepos,desirero;
    Rigidbody rb;
    Animator anim;
    [SerializeField]
    GameObject Playerobj;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5f;
        anim = Playerobj.GetComponentInChildren<Animator>();

    }
    private void Update()
    {
        XDirection = Input.GetAxis("Horizontal");
        YDirection = Input.GetAxis("Vertical");

        desirepos = new Vector3(0, 0,YDirection) * speed;
        desirepos *= Time.deltaTime;
        transform.Translate(desirepos);
        desirero = new Vector3(0, XDirection, 0)*2;
        transform.Rotate(desirero);
        
        if(desirepos != Vector3.zero)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

    }

  
}
