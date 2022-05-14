using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloundBehavior : MonoBehaviour
{
    float startpos;
    float speed = 3;
    bool moveright = true;
    private void Start()
    {
        startpos = this.transform.position.x;
    }

    void Update()
    {
      if(transform.position.x > startpos + 1.5f)
        {
            moveright = false;
        }
      if(transform.position.x< startpos - 1.5f)
        {
            moveright = true;
        }
        if (moveright)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime,transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

}
