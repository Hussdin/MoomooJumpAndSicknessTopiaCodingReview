using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBsetting : MonoBehaviour
{
    [SerializeField]
    Toggle sniffT, coughtT, bleedingT;
    [SerializeField]
    Text diseases;

    List<string> Disease = new List<string>();
    public bool sniff, cought, bleeding;
    int num,plus;
    bool canchange;
    private void Awake()
    {
        sniffT.isOn = false;
        coughtT.isOn = false;
        bleedingT.isOn = false;
        Disease.Add("A");
        Disease.Add("B");
    }
    private void Update()
    {
        diseases.text = Disease[num];
        check();
        checkdisease();
        checkbool();
    }
    void checkbool()
    {
        if(sniff && cought && !bleeding) { num = 0; canchange = false; }
        if(sniff && cought && bleeding) { num = 1; canchange = false; }
        else { canchange = true; }
    }
    void check()
    {
        if (sniffT.isOn) { sniff = true; }
        if(coughtT.isOn) { cought = true; }
        if(bleedingT.isOn) { bleeding = true; }
        if (!sniffT.isOn) { sniff = false; }
        if (!coughtT.isOn) { cought = false; }
        if (!bleedingT.isOn) { bleeding = false; }
    }

    void checkdisease()
    {
        if(plus%2 == 0)
        {
            num = 0;
        }
        else
        {
            num = 1;
        }
    }

    public void onclickL()
    {
       
        if (plus <0 && canchange)
        {
            plus = 0;
        }
        else { plus--; }
    }

    public void onclickR()
    {
        if(plus > 1 && canchange)
        {
           plus = 1;
        }
        else { plus++; }
    }
}
