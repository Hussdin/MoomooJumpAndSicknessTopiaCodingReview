using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiseaseInformation : MonoBehaviour
{
    public static DiseaseInformation infomation;
    string disease;
    public int amount;
    Dictionary<string, string> symtom;
    //public string[] symtoms = { "", "", "", "" };
    public List<string> symtomss;
    private void Awake()
    {
        infomation = this;
    }
    private void Start()
    {
        disease = this.GetComponent<Profile>().Disease;
        GenDictionary();
    }

    void GenDictionary()
    {
        switch (disease)
        {
            case "A":
                symtom = new Dictionary<string, string>();
                symtom.Add("0", "sniff");
                symtom.Add("1", "cough");
                getsymtom();
                break;
            case "B":
                symtom = new Dictionary<string, string>();
                symtom.Add("0", "sniff");
                symtom.Add("1", "cough");
                symtom.Add("2", "bleeding");
                getsymtom();
                break;
        }
    }

    public void getsymtom()
    {
        amount = symtom.Count;
        for (int i = 0; i < symtom.Count; i+=1)
        {
            symtomss.Add(symtom[i.ToString()]);
        }
    }
}
