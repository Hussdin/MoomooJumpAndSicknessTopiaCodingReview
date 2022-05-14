using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    Animator anim;
    public GameObject player,StartPanel;
    void Start()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 0;   
        anim = GetComponent<Animator>();
        anim.SetBool("isCircleActive", true);
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            StartPanel.SetActive(false);
            anim.SetBool("isCircleActive", false);
        }   
    }
}
