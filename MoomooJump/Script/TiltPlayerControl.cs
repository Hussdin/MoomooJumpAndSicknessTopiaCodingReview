using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPlayerControl : MonoBehaviour
{
     Rigidbody2D rb;
    float movespd = 1/10f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = Vector2.right * Input.acceleration.x;
        this.transform.Translate(direction*movespd);
    }
}
