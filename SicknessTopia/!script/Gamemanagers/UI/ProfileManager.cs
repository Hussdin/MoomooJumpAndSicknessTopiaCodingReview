using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text Names, Gender, Age, High, Weight, BG, BP, Disease,s1,s2,s3,s4,s5,Allergy,temp;
    [SerializeField]
    Image Profile;
    [SerializeField]
    Sprite defaultprofile;

    Profile patientprofile;

    public GameObject patient;
    private void Awake()
    {
        patient = null;
    }
    private void OnEnable()
    {
        patient = GameObject.Find("Player").GetComponent<PlayerBehaviorControll>().Patients;
        if (patient == null)
        {
            Profile.sprite = defaultprofile;
            Names.text = "ชื่อ : ";
            Gender.text = "เพศ :";
            Age.text = "อายุ :";
            High.text = "ส่วนสูง :";
            Weight.text = "น้ำหนัก :";
            BG.text = "กรุ๊ปเลือด : ";
            BP.text = "ความดันเลือด :";
            Disease.text = "โรค : ยังไม่ได้วินิจฉัย";
            s1.text = "";
            s2.text = "";
            s3.text = "";
            s4.text = "";
            s5.text = "";
            temp.text = "อุณหภูมิร่างกาย : ";
        }

        else if(patient != null)
        {
            patientprofile = patient.GetComponent<Profile>();

            Profile.sprite = patientprofile.MyPicture;
            Names.text = "ชื่อ : " + patientprofile.name;
            Gender.text = "เพศ :" + patientprofile.Gender; ;
            Age.text = "อายุ :" + patientprofile.age;
            High.text = "ส่วนสูง :" + patientprofile.high;
            Weight.text = "น้ำหนัก :" + patientprofile.weight;
            BG.text = "กรุ๊ปเลือด : " + patientprofile.BG;
            BP.text = "ความดันเลือด :" + patientprofile.bp;
            Disease.text = "โรค : "+patientprofile.PredictionDisease;
            Allergy.text = "สิ่งที่แพ้ :" + patientprofile.allergytest;
            temp.text = "อุณหภูมิร่างกาย : "+patientprofile.temp;

            s1.text = patientprofile.s1;
            s2.text = patientprofile.s2;
            s3.text = patientprofile.s3;
            s4.text = patientprofile.s4;
            s5.text = patientprofile.s5;
        }
    }

    public void predictdisease(string disease)
    {
        Disease.text = "โรค : " + disease;
    } 


}
