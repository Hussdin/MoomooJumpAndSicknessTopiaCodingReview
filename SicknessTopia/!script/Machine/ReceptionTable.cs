using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionTable : MonoBehaviour
{
    SoundManager sound;
    EventManager eventManager;
    public static ReceptionTable reception;
    PatientBehavior patientbehav;
    [SerializeField]
    GameObject patientpos;
    GameObject Patient;
    public GameObject informationSign;
    public int que;
    bool pressed,stay,empthy;
    bool alreadyshow;
    private void Awake()
    {
        que = 1;
        reception = this;
        empthy = true;
    }
    private void Start()
    {
        eventManager = EventManager.gameevent;
        sound = SoundManager.sound;
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stay = true;
            if (pressed && stay && empthy)
            {
                eventManager.announceQue(que);

                sound.PLayAnnounce();
                pressed = false;
            }
        }
        if (collision.gameObject.CompareTag("Patient"))
        {
            empthy = false;
            informationSign.SetActive(false);
        }
    }
    void closeEicon(GameObject Player)
    {
        Player.gameObject.GetComponent<PlayerBehaviorControll>().closeEIcon();
        alreadyshow = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stay = true;
            if (!alreadyshow)
            {
                other.GetComponent<PlayerBehaviorControll>().showEIcon();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stay = false;
            closeEicon(other.gameObject);
        }
        if (other.gameObject.CompareTag("Patient"))
        {
            empthy = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && stay)
        {
            pressed = true;
            informationSign.SetActive(true);
        }
    }
}
