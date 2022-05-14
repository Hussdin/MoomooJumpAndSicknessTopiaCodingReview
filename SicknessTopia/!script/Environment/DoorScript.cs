using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    SoundManager sound;

    [SerializeField]
    GameObject door;

    Animator anim;
    bool stay;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        sound = SoundManager.sound;
    }
    void opendoor()
    {
        anim.SetBool("Open",true);
    }
    void closedoor()
    {
        anim.SetBool("Open", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Patient"))
        {
            playesound();
            stay = true;
            opendoor();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Patient"))
        {
            opendoor();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Patient"))
        {
            stay = false;
            playesound();
            closedoor();
        }
    }
    void playesound()
    {
        if (stay)
        {

        }
        else
        {
            sound.playerDoor();
        }
    }
}
