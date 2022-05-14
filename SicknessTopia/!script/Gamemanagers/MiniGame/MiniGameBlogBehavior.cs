using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameBlogBehavior : MonoBehaviour
{
    PredictionSystem patientidentify;
    [SerializeField]
    Button eye, troat, listening, temp;
    [SerializeField]
    Sprite DoneBTN,defaultBTN;

    GameObject patient;
    private void OnEnable()
    {
        patientidentify = PredictionSystem.predicsys;
        patient = patientidentify.Patient;
        if (patient != null)
        {
            UpdateEye(patient);
            UpdateListening(patient);
            UpdateTemp(patient);
            UpdateTroat(patient);
        }
    }
    private void Start()
    {
        patientidentify = PredictionSystem.predicsys;
        patient = patientidentify.Patient;
    }
    void UpdateEye(GameObject Patient)
    {
        if(Patient.GetComponent<PatientsQuestData>().Eye > 0)
        {
            eye.interactable = true;
            eye.GetComponent<Image>().sprite = defaultBTN;
        }
        else
        {
            eye.interactable = false;
            eye.GetComponent<Image>().sprite = DoneBTN;
        }
    }
    void UpdateTroat(GameObject Patient)
    {
        if (Patient.GetComponent<PatientsQuestData>().Eye > 0)
        {
            troat.interactable = true;
            troat.GetComponent<Image>().sprite = defaultBTN;
        }
        else
        {
            troat.interactable = false;
            troat.GetComponent<Image>().sprite = DoneBTN;
        }
    }
    void UpdateListening(GameObject Patient)
    {
        if (Patient.GetComponent<PatientsQuestData>().Eye > 0)
        {
            listening.interactable = true;
            listening.GetComponent<Image>().sprite = defaultBTN;
        }
        else
        {
            listening.interactable = false;
            listening.GetComponent<Image>().sprite = DoneBTN;
        }
    }
    void UpdateTemp(GameObject Patient)
    {
        if (Patient.GetComponent<PatientsQuestData>().Eye > 0)
        {
            temp.interactable = true;
            temp.GetComponent<Image>().sprite = defaultBTN;
        }
        else
        {
            temp.interactable = false;
            temp.GetComponent<Image>().sprite = DoneBTN;
        }
    }
}
