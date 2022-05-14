using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController animcontroll;
    Animator anim;
    bool IsMoving;
    private void Awake()
    {
        animcontroll = this;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CheckMoving(this.gameObject);
        if (/*Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0*/ IsMoving)
        {
            anim.Play("Walk");
        }
        else
        {
            anim.Play("Stand Idle");
        }
    }
    void CheckMoving(GameObject Object)
    {
        if (Object.GetComponent<Rigidbody>().velocity.magnitude > 0.01f)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }
    public void Walk()
    {
        anim.Play("Walk");
    }
    public void stayIdle()
    {
        anim.Play("Stand Idle");
    }
}
