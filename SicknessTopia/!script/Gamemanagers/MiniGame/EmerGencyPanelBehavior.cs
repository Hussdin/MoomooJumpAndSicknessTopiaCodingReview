using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmerGencyPanelBehavior : MonoBehaviour
{
    GameObject Patient;
    EmergencyBed bed;
    [SerializeField]
    GameObject Abras,Stale, Cut, Hot;
    [SerializeField]
    GameObject tool1, t2, t3, t4, t5, t6,t7;
    string disease;
    private void OnEnable()
    {
        bed = EmergencyBed.emergencyBed;
        Patient = bed.Patient;
        disease = Patient.GetComponent<SpecialProfile>().Disease;
        checkdisease();
    }
    private void OnDisable()
    {
        Abras.SetActive(false);
        Stale.SetActive(false);
        Cut.SetActive(false);
        Hot.SetActive(false);

        tool1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(false);
        t4.SetActive(false);
        t5.SetActive(false);
        t6.SetActive(false);
        t7.SetActive(false);
    }
    void checkdisease()
    {
        switch (disease)
        {
            default:
                break;
            case "แผลถลอก":
                Abras.SetActive(true);
                break;
            case "แผลฟกช้ำ":
                Stale.SetActive(true);
                break;
            case "แผลถูกของมีคมบาด":
                Cut.SetActive(true);
                break;
            case "แผลน้ำร้อนลวก":
                Hot.SetActive(true);
                break;
        }
    }

}
