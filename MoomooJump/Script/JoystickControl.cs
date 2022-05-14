using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    public float speed = 1/10;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;

    void Update()
    {
        Vector2 direction = Vector2.right * variableJoystick.Horizontal;
        this.transform.Translate(direction*speed);
    }

}
