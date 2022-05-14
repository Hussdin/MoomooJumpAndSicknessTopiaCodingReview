using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialProfile : Profile
{
    public int TreatditionLeft;
    private void Awake()
    {
        TreatditionLeft = 1;
        isspecial = true;
    }
    public override void checkGameMode()
    {
        int day = data.day;
        if (day == 0)
        {
            RandomSpecialdiseaseforTestMode();
            this.gameObject.GetComponent<PatientsEmotional>().checmedcantake(this.gameObject);
        }
        else
        {
            RandomDisease(0.4f, 0.6f, 0.8f, 0.9f, 1f);
            this.gameObject.GetComponent<PatientsEmotional>().checmedcantake(this.gameObject);
        }
    }
    public override void RandomDisease(float SR1, float SR2, float SR3, float SR4, float SR5)
    {
        float chance = Random.value;
        if (chance < SR1)
        {
            Disease = "แผลถลอก";
        }
        else if (chance > SR1 && chance < SR2)
        {
            Disease = "แผลฟกช้ำ";
        }
        else if (chance > SR2 && chance < SR4)
        {
            Disease = "แผลถูกของมีคมบาด";
        }
        else if (chance > SR4)
        {
            Disease = "แผลน้ำร้อนลวก";
        }
    }
}
