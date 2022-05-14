using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class PredictionSystem : MonoBehaviour
{
    public static PredictionSystem predicsys;

    protected string FileName;
    string Disease;
    string[] datas;

    int releasecount;

    public GameObject Patient, Player;
    private void Awake()
    {
        predicsys = this;
        FileName = "SymtompsDocument.csv";
        releasecount = 0;
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
        if (Disease == value[disease])
        {
            datas = value;
        }
    }
    List<string> RandomSymptom = new List<string>();
    bool addlist;
    void setsymtomp()
    {
        if (!addlist)
        {
            string d1, d2, d3, ds, dr, ld;
            d1 = datas[1];
            d2 = datas[2];
            d3 = datas[3];
            ds = datas[4];
            dr = datas[UnityEngine.Random.Range(5, 7)];

            RandomSymptom.Add(d1);
            RandomSymptom.Add(d2);
            RandomSymptom.Add(d3);
            RandomSymptom.Add(ds);
            if(dr != "")
            {
                RandomSymptom.Add(dr);
            }
        }
        addlist = true;

    }
    public string GetSymtomp(string dialog,string type)
    {
        if (type == "Symptom")
        {
            if (RandomSymptom.Count >=1)
            {
                int count = UnityEngine.Random.Range(0,RandomSymptom.Count);
                dialog = RandomSymptom[count];
                RandomSymptom.Remove(dialog);
            }
            else
            {
                dialog = "ไม่มีแล้ว";
            }
            

        }
        return dialog;
    }

    int disease,symptom1, symptom2, symptom3;
    int duration1, duration2, duration3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            Patient = other.gameObject;
            Disease = Patient.GetComponent<Profile>().Disease;
            ConfigData();
            setsymtomp();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            Patient = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            Patient = null;
            Disease = "";
            addlist = false;
            RandomSymptom.Clear();
        }
    }
}
