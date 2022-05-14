using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGameDatatoconfig : MonoBehaviour
{
    public static CurrentGameDatatoconfig savegame;
  
    public int day;
    public int Erate;
    public int money ;
    public int hospitallevel;
    public string savename;
    private void Awake()
    {
        savegame = this;
    }
    void setdefaultsave()
    {
      day = 0;
      money = 0;
      hospitallevel = 1;

    }
    public void savedata(string key,string savetype)
    {
        if(savetype == "DefaultSave")
        {
            setdefaultsave();
            savename = key;
            SaveSystem.SaveData(this, key);
        }
        else
        {
            savename = key;
            SaveSystem.SaveData(this, key);
        }
    }
    public void loaddata(string key)
    {
        if (key != "Empthy")
        {
            CurrentData data = SaveSystem.LoadSave(key);

            day = data.Day;
            money = data.Money;
            hospitallevel = data.HospitalLevel;
            savename = data.savename;
        }
    }
    
}
