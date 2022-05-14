using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
     public void UpdateDoneQuest(GameObject Patient)
     {
        Patient.GetComponent<PatientsQuestData>().OrdinaryQuestLeft -= 1;
     }
}
