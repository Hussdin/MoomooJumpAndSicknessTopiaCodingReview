using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropscene : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    float jump = 7;
    [SerializeField]
    AudioSource jumpsound;
    bool isfalling;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void checkjump()
    {
        if (rb.velocity.y < -0)
        {
            isfalling = true;
            anim.SetBool("Jump", false);
        }
        else
        {
            isfalling = false;
        }
    }
    private void Update()
    {
        checkjump();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Clound") && isfalling == true )
        {
            Vector2 velocity = rb.velocity;
            velocity.y = jump;
            velocity.x = 0;
            rb.velocity = velocity;
            jumpsound.Play();
            anim.SetBool("Jump", true);
        }
    }
}
