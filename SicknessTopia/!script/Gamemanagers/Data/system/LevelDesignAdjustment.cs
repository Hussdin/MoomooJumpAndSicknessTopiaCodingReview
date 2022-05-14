using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class LevelDesignAdjustment : MonoBehaviour
{
    int Day;
    int DayPositionInDoc,ErateInDocposition;
    public static LevelDesignAdjustment LvAdjust;
    CurrentGameDatatoconfig Datacontainers;
    protected string FileName;

    private void Awake()
    {
        LvAdjust = this;
        ErateInDocposition = 2;
        FileName = "LevelDesignDoc.csv";
    }
    private void Start()
    {
        Datacontainers = CurrentGameDatatoconfig.savegame;
        Day = Datacontainers.day;
        DayPositionInDoc = 0;
        ConfigData();
    }

    void ConfigData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, FileName));
            string name = input.ReadLine();
            string value = input.ReadLine();

            while (value != null)
            {
                sentConf(value);
                value = input.ReadLine();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    void sentConf(string csvValue)
    {
        string[] value = csvValue.Split(',');
        if (Day == int.Parse(value[DayPositionInDoc]))
        {
            senddatatoSO(Day, int.Parse(value[ErateInDocposition]));
        }
    }

    void senddatatoSO(int day, int erate)
    { 
        Datacontainers.day = day;
        Datacontainers.Erate = erate;
    }
}
