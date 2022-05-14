using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDayManager : MonoBehaviour
{
    public static FirstDayManager firstday;
    public List<string> Diseasenametotest = new List<string>();
    public List<string> SpecialSisease = new List<string>();
    private void Awake()
    {
        firstday = this;
        setdisease();
        setspecialdisease();
    }
    public string getdisease(string PatientType)
    {
        if (PatientType == "Normal")
        {
            int pos = Random.Range(0, Diseasenametotest.Count);
            string disease = Diseasenametotest[pos];
            Diseasenametotest.RemoveAt(pos);

            return disease;
        }
        else
        {
            int pos = Random.Range(0, SpecialSisease.Count);
            string disease = SpecialSisease[pos];
            SpecialSisease.RemoveAt(pos);

            return disease;
        }  
    }
    void setdisease()
    {
        Diseasenametotest.Add("ไข้หวัดธรรมดา");
        Diseasenametotest.Add("ไข้หวัดคออักเสบ(เชื้อไวรัส)");
        Diseasenametotest.Add("ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)");
        Diseasenametotest.Add("ไข้หวัดปอดอักเสบ");
        Diseasenametotest.Add("ภูมิแพ้");
    }
    void setspecialdisease()
    {
        SpecialSisease.Add("แผลถลอก");
        SpecialSisease.Add("แผลฟกช้ำ");
        SpecialSisease.Add("แผลถูกของมีคมบาด");
        SpecialSisease.Add("แผลน้ำร้อนลวก");
    }
}
