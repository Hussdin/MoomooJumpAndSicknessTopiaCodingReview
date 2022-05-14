using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayHospitalScript : MonoBehaviour
{
    MedicBedBehavior bed;
    [SerializeField]
    GameObject MinigamePanel,wholePanel;
    [SerializeField]
    GameObject SyminiGame, Skintest,Takemidicine;

    string mode;
    private void Start()
    {
        bed = MedicBedBehavior.Medicbed;
    }
    public void onclickAmox()
    {
        bed.CommadPatientToBed();
        wholePanel.SetActive(true);
    }
    public void openminigame()
    {
        MinigamePanel.SetActive(true);
    }
    
}
