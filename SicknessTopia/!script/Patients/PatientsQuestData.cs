using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientsQuestData : MonoBehaviour
{
    public static PatientsQuestData quest;
    public int OrdinaryQuestLeft;
    public int SpecialQuestLeft;
    public bool DoneOrdinaryQuest;

    public int Listening, Troat, Eye, Temp,SearchingBodyLeft,Xrayleft,Skintestleft,LiquidTestleft, Takemedicineleft,lableft, TakeAmoxleft,asksymtomps,predict, Takemed1, Takemed2;
    public GameObject Patient; 
    private void Awake()
    {
        Patient = this.gameObject;

        quest = this;
        OrdinaryQuestLeft = 3;
        SpecialQuestLeft = 0;
        SearchingBodyLeft = 4;
        Listening = 3;
        Troat = 2;
        Eye = 2;
        Temp = 1;
        Xrayleft = 1;
        Skintestleft = 1;
        LiquidTestleft = 1;
        Takemedicineleft = 1;
        lableft = 1;
        TakeAmoxleft = 2;
        Takemed1 = 1;
        Takemed2 = 1;
        asksymtomps = 6;
        predict = 1;


    }
    
}
