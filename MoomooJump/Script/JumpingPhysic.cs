using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPhysic : MonoBehaviour
{
    StatusScript status;

    float jumpforce;
    public static bool isfalling;
    Rigidbody2D rb;
    ObjectPooler objectPooler;
    Animator anim;

    public AudioSource jump;

    private void Awake()
    {
        status = StatusScript.status;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        objectPooler = ObjectPooler.Instance;
        jumpforce = status.Jumpforce;
        checkjump();
    }
    void checkjump()
    {
        if(rb.velocity.y < -0)
        {
            isfalling = true;
            anim.SetBool("Jump", false);
        }
        else
        {
            isfalling = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Clound") && isfalling == true)
        {
            anim.SetBool("Jump", true);
            Vector2 velocity = rb.velocity;
            velocity.y = jumpforce;
            velocity.x = 0;
            rb.velocity = velocity;
            jump.Play();
        }

        if (collision.gameObject.CompareTag("MoveClound") && isfalling == true)
        {
            anim.SetBool("Jump", true);
            Vector2 velocity = rb.velocity;
            velocity.y = jumpforce;
            velocity.x = 0;
            rb.velocity = velocity;
            jump.Play();

        }

        if (collision.gameObject.CompareTag("FluffyClound") && isfalling == true)
        {
            anim.SetBool("Jump", true);
            Vector2 velocity = rb.velocity;
            velocity.y = jumpforce;
            velocity.x = 0;
            rb.velocity = velocity;
            collision.gameObject.SetActive(false);
            objectPooler.Addqueue(collision.gameObject.tag, collision.gameObject);
            jump.Play();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pillar") && isfalling == true)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = jumpforce;
            velocity.x = 0;
            rb.velocity = velocity;

        }

        if (collision.gameObject.CompareTag("UltimateBoost"))
        {
            Destroy(this.gameObject);
        }
    }
}
