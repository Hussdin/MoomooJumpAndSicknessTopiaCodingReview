using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyBed : MonoBehaviour
{
    public static EmergencyBed emergencyBed;
    public GameObject Patient, Player;
    [SerializeField]
    GameObject bedpos,Panel,Cam;
    bool Entry;
    private void Awake()
    {
        emergencyBed = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Entry = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player = other.gameObject;
            Player.GetComponent<PlayerBehaviorControll>().showEIcon();
            Cam.SetActive(true);
        }
        if (other.gameObject.CompareTag("Patient"))
        {
            Patient = other.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Patient != null && other.gameObject.CompareTag("Player"))
        {
            if (Entry)
            {
                Player.GetComponent<PlayerBehaviorControll>().losePatient();
                Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(bedpos.transform.position, bedpos.transform.rotation);
                Invoke("turnonPanel", 1);
                Entry = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            other.GetComponent<PatientBehavior>().closedoneicon();
            Patient = null;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<PlayerBehaviorControll>().closeEIcon();
            Entry = false;
            Cam.SetActive(false);
        }
    }
    void turnonPanel()
    {
        if (Patient.GetComponent<SpecialProfile>().TreatditionLeft >0)
        {
            if (Panel.activeInHierarchy)
            {
                Panel.SetActive(false);
            }
            else
            {
                Panel.SetActive(true);
            }
        }
    }
    public void turnoffPanel()
    {
        Panel.SetActive(false);
    }
    public void onDoneTreat()
    {
        Patient.GetComponent<SpecialProfile>().TreatditionLeft = 0;
        turnoffPanel();
    }
}
