using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
using System.IO;

[System.Serializable]
public class CurrentData 
{
    public int Day;
    public int Money;
    public int HospitalLevel;
    public string savename;

    public CurrentData(CurrentGameDatatoconfig Datacontainers)
    {
        Day = Datacontainers.day;
        Money = Datacontainers.money;
        HospitalLevel = Datacontainers.hospitallevel;
        savename = Datacontainers.savename;
    }
}
