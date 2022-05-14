using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialEvent : MonoBehaviour
{
    DayManagement dayManagement;
    Anbulance ambulance;
    
    [SerializeField]
    GameObject Ambulance;
    [SerializeField]
    GameObject ambulancepos, ambudesirepos;

    public float timecount;
    float day;
    int coundSpawnForFirstDay;
    private void Start()
    {
        dayManagement = DayManagement.daymanage;
        day = dayManagement.Day;
        coundSpawnForFirstDay = 4;

    }
    void Checktimeofevent()
    {
        if(timecount >= 120)
        {
            CallEvent();
            Reset();
        }
    }
    public void CallEvent()
    {
        if (day == 0)
        {
            if (coundSpawnForFirstDay > 0)
            {
                coundSpawnForFirstDay--;
                ambulance = Anbulance.ambulance;
                ambulance.onduty = true;
            }
        }
        else
        {
            ambulance = Anbulance.ambulance;
            ambulance.onduty = true;
        }
       
    }
    void Update()
    {
        timecount += Time.deltaTime;
        Checktimeofevent();
    }
    private void Reset()
    {
        timecount = 0;
    }

}
