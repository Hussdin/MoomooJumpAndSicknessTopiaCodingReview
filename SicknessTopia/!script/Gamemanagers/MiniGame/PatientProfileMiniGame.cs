using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientProfileMiniGame : MonoBehaviour
{
    [SerializeField]
    Sprite ID1, ID2, ID3, ID4, ID5, ID6;

    PredictionSystem PatiebtIdentify;
    GameObject Patient;
    int ID;
    private void Awake()
    {
        
        PatiebtIdentify = PredictionSystem.predicsys;
        Patient = PatiebtIdentify.Patient;
        if(Patient != null)
        {
            ID = Patient.GetComponent<Profile>().PatientsPersonalize;
        }
        setPatient();
    }
    private void OnEnable()
    {
        PatiebtIdentify = PredictionSystem.predicsys;
        Patient = PatiebtIdentify.Patient;
        if (Patient != null)
        {
            ID = Patient.GetComponent<Profile>().PatientsPersonalize;
        }
        setPatient();
    }
    void setPatient()
    {
        switch (ID)
        {
            case 1:
                this.gameObject.GetComponent<Image>().sprite = ID1;
                break;
            case 2:
                this.gameObject.GetComponent<Image>().sprite = ID2;
                break;
            case 3:
                this.gameObject.GetComponent<Image>().sprite = ID3;
                break;
            case 4:
                this.gameObject.GetComponent<Image>().sprite = ID4;
                break;
            case 5:
                this.gameObject.GetComponent<Image>().sprite = ID5;
                break;
            case 6:
                this.gameObject.GetComponent<Image>().sprite = ID6;
                break;

        }
    }
}
