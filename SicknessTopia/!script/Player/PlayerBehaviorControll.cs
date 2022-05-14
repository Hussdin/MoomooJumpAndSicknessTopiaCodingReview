using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviorControll : MonoBehaviour
{
    public static PlayerBehaviorControll player;
    QuestLogGuide QuestBlockController;

    bool lookatPatient;
    bool withpatient;
    Vector3 DesirePos;
    public GameObject Patients;

    [SerializeField]
    GameObject DocFollowPos,EIcon;
  
    private void Start()
    {
        QuestBlockController = QuestLogGuide.QuestBlockController;
    }
    private void Update()
    {
        pressspace();
        if (withpatient)
        {
            Patients.GetComponent<PatientBehavior>().ChangePatientDesirePosition(DocFollowPos.transform.position, DocFollowPos.transform.rotation);
            QuestBlockController.updateQuestBoard(Patients);
        }
        if (Input.GetKey(KeyCode.E))
        {
            EIcon.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Patient"))
        {
            if (!withpatient)
            {
               Patients =  collision.gameObject;
            }
        }
        if (collision.gameObject.CompareTag("PredictTable"))
        {
            EIcon.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Patient"))
        {
            if (!withpatient)
            {
                Patients = collision.gameObject;
                lookatPatient = true;
                EventManager.gameevent.EnteringPatients(collision.gameObject.name);
            }
        }
        if (collision.gameObject.CompareTag("PredictTable"))
        {
            EIcon.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Patient"))
        {
            lookatPatient = false;
            EventManager.gameevent.ExitingPatient(collision.gameObject.name);
        }
        if (collision.gameObject.CompareTag("PredictTable"))
        {
            EIcon.SetActive(false);
        }
    }
    
    public void pressspace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (lookatPatient)
            {
               withpatient = !withpatient;
               Patients.GetComponent<PatientBehavior>().evertakecare = true;
               CreateQuest(Patients);
            }
            if (!lookatPatient)
            {
                withpatient = false;
                QuestBlockController.CloseQuestBlock();
                Patients = null;
            }
        }
    }
    void CreateQuest(GameObject Patient)
    {
        if (Patient.GetComponent<Profile>().isspecial)
        {
            QuestBlockController.CreateEmergencyCase(Patient);
        }
        else
        {
            QuestBlockController.CreateSpecialQuest(Patient);
        }
    }
    public void losePatient()
    {
        QuestBlockController.CloseQuestBlock();
        withpatient = false;
    }
    public void showEIcon()
    {
        EIcon.SetActive(true);
    }
    public void closeEIcon()
    {
        EIcon.SetActive(false);
    }
}
