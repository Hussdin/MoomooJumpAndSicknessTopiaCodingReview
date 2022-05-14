using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistoryBoardBehavior : MonoBehaviour
{
    [SerializeField]
    TMP_Text Disease, Pdisease,Name,BoxName;
    [SerializeField]
    TMP_Text Method1, Method2, Method3, Method4, Method5, Method6;
    [SerializeField]
    TMP_Text PMethod1, PMethod2, PMethod3, PMethod4, PMethod5, PMethod6;
    [SerializeField]
    Image Profile, SmallProfile;
    [SerializeField]
    GameObject MedicineTxtTocreate, TextboxareaofMedicine;

    [SerializeField]
    TMP_Text Requiremed1, Requiremed2, Requiremed3, Requiremed4;

    [SerializeField]
    GameObject EmotionImage;
    [SerializeField]
    Sprite HappyFace, BoredFace, AngryFace, MadFace;

    GameObject Patient;

    List<string> Requiremedlist = new List<string>();
    void getinfo()
    {
        string disease = Patient.GetComponent<Profile>().Disease;
        Disease.text = disease;
        Pdisease.text = Patient.GetComponent<Profile>().PredictionDisease;
        if (Pdisease.text != Disease.text)
        {
            Pdisease.GetComponent<TMP_Text>().color = new Color32(214, 75, 75, 255);
        }

        switch (disease)
        {
            default:
                break;
            case "ไข้หวัดธรรมดา":
                Method1.text = "ตรวจร่างกาย";
                Method1.gameObject.SetActive(true);
                Method2.text = "ให้ยาตามอาการ";
                Method2.gameObject.SetActive(true);
                Method3.text = "";
                Method4.text = "";

                PMethod1.text = "ตรวจร่างกาย";
                PMethod1.gameObject.SetActive(true);
                PMethod2.text = "ให้ยาตามอาการ";
                PMethod2.gameObject.SetActive(true);
                PMethod3.text = "";
                PMethod4.text = "";
                break;

            case "ไข้หวัดคออักเสบ(เชื้อไวรัส)":
                Method1.text = "ตรวจร่างกาย";
                Method1.gameObject.SetActive(true);
                Method2.text = "ให้ยาตามอาการ";
                Method2.gameObject.SetActive(true);
                Method3.text = "";
                Method4.text = "";

                PMethod1.text = "ตรวจร่างกาย";
                PMethod1.gameObject.SetActive(true);
                PMethod2.text = "ให้ยาตามอาการ";
                PMethod2.gameObject.SetActive(true);
                PMethod3.text = "";
                PMethod4.text = "";
                break;

            case "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)":
                Method1.text = "ตรวจร่างกาย";
                Method1.gameObject.SetActive(true);
                Method2.text = "ให้ยาตามอาการ";
                Method2.gameObject.SetActive(true);
                Method3.text = "";
                Method4.text = "";

                PMethod1.text = "ตรวจร่างกาย";
                PMethod1.gameObject.SetActive(true);
                PMethod2.text = "ให้ยาตามอาการ";
                PMethod2.gameObject.SetActive(true);
                PMethod3.text = "";
                PMethod4.text = "";
                break;

            case "ไข้หวัดปอดอักเสบ":
                Method1.text = "ตรวจร่างกาย";
                Method1.gameObject.SetActive(true);
                Method2.text = "ตรวจเสมหะ";
                Method2.gameObject.SetActive(true);
                Method3.text = "X-Ray";
                Method3.gameObject.SetActive(true);
                Method4.text = "นำเสมหะไปทดสอบ";
                Method4.gameObject.SetActive(true);
                Method5.text = "ฉีดยา Amoxicillin";
                Method5.gameObject.SetActive(true);
                Method6.text = "ให้ยาตามอาการ";
                Method6.gameObject.SetActive(true);

                PMethod1.text = "ตรวจร่างกาย";
                PMethod1.gameObject.SetActive(true);
                PMethod2.text = "ตรวจเสมหะ";
                PMethod2.gameObject.SetActive(true);
                PMethod3.text = "X-Ray";
                PMethod3.gameObject.SetActive(true);
                PMethod4.text = "นำเสมหะไปทดสอบ";
                PMethod4.gameObject.SetActive(true);
                PMethod5.text = "ฉีดยา Amoxicillin";
                PMethod5.gameObject.SetActive(true);
                PMethod6.text = "ให้ยาตามอาการ"; ;
                PMethod6.gameObject.SetActive(true);
                break;
            case "ภูมิแพ้":
                Method1.text = "ตรวจร่างกาย";
                Method1.gameObject.SetActive(true);
                Method2.text = "ตรวจสารที่แพ้";
                Method2.gameObject.SetActive(true);
                Method3.text = "นำสารที่แพ้ไปทดสอบ";
                Method3.gameObject.SetActive(true);
                Method4.text = "ให้ยาตามอาการ";
                Method4.gameObject.SetActive(true);

                PMethod1.text = "ตรวจร่างกาย";
                PMethod1.gameObject.SetActive(true);
                PMethod2.text = "ตรวจสารที่แพ้";
                PMethod2.gameObject.SetActive(true);
                PMethod3.text = "นำสารที่แพ้ไปทดสอบ";
                PMethod3.gameObject.SetActive(true);
                PMethod4.text = "ให้ยาตามอาการ";
                PMethod4.gameObject.SetActive(true);
                break;
        }
    }
    void getPlayerPlayInfo()
    {
        string disease = Patient.GetComponent<Profile>().Disease;
        switch (disease)
        {
            default:
                break;
            case "ไข้หวัดธรรมดา":
                if (Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft == 0)
                {
                    PMethod1.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().Takemedicineleft == 0)
                {
                    PMethod2.color = new Color32(100, 172, 51, 255);
                }
                break;

            case "ไข้หวัดคออักเสบ(เชื้อไวรัส)":
                if (Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft == 0)
                {
                    PMethod1.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().Takemedicineleft == 0)
                {
                    PMethod2.color = new Color32(100, 172, 51, 255);
                }
                break;

            case "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)":
                if (Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft == 0)
                {
                    PMethod1.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().Takemedicineleft == 0)
                {
                    PMethod2.color = new Color32(100, 172, 51, 255);
                }
                break;

            case "ไข้หวัดปอดอักเสบ":
                if (Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft == 0)
                {
                    PMethod1.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().Takemedicineleft == 0)
                {
                    PMethod6.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().Xrayleft == 0)
                {
                    PMethod3.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().TakeAmoxleft == 0)
                {
                    PMethod5.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().LiquidTestleft == 0)
                {
                    PMethod2.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().lableft == 0)
                {
                    PMethod4.color = new Color32(100, 172, 51, 255);
                }
                break;
            case "ภูมิแพ้":
                if (Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft == 0)
                {
                    PMethod1.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().Takemedicineleft == 0)
                {
                    PMethod4.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().Skintestleft == 0)
                {
                    PMethod2.color = new Color32(100, 172, 51, 255);
                }
                if (Patient.GetComponent<PatientsQuestData>().lableft == 0)
                {
                    PMethod3.color = new Color32(100, 172, 51, 255);
                }
                break;
        }
    }

    void getMedicineInformation()
    {
        string disease = Patient.GetComponent<Profile>().Disease;
        
        switch (disease)
        {
            default:
                break;

            case "ไข้หวัดธรรมดา":

                Requiremed1.text = "Dextromethorphan ยาแก้ไอ(แบบไม่มีเสมหะ)";
                Requiremed2.text = "Paracetamol ยาแก้ปวดลดไข้";
                Requiremed3.text = "Cholpheniramine ยาแก้แพ้(ช่วยลดน้ำมูกได้ดี)";
                Requiremed4.text = "";

                Requiremedlist.Add(Requiremed1.text);
                Requiremedlist.Add(Requiremed2.text);
                Requiremedlist.Add(Requiremed3.text);

                createMedicineTxt();
                break;

            case "ไข้หวัดคออักเสบ(เชื้อไวรัส)":
                Requiremed1.text = "Carbocysteine ยาแก้ไอ (แบบมีเสมหะ)";
                Requiremed2.text = "Paracetamol ยาแก้ปวดลดไข้";
                Requiremed3.text = "";
                Requiremed4.text = "";

                Requiremedlist.Add(Requiremed1.text);
                Requiremedlist.Add(Requiremed2.text);


                createMedicineTxt();
                break;

            case "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)":
                Requiremed1.text = "Amoxicillin ยาปฏิชีวนะ";
                Requiremed2.text = "Carbocysteine ยาแก้ไอ (แบบมีเสมหะ)";
                Requiremed3.text = "Paracetamol ยาแก้ปวดลดไข้";
                Requiremed4.text = "";

                Requiremedlist.Add(Requiremed1.text);
                Requiremedlist.Add(Requiremed2.text);
                Requiremedlist.Add(Requiremed3.text);

                createMedicineTxt();
                break;

            case "ไข้หวัดปอดอักเสบ":
                Requiremed1.text = "Amoxicillin ยาปฏิชีวนะ";
                Requiremed2.text = "Paracetamol ยาแก้ปวดลดไข้";
                Requiremed3.text = "";
                Requiremed4.text = "";

                Requiremedlist.Add(Requiremed1.text);
                Requiremedlist.Add(Requiremed2.text);

                createMedicineTxt();
                break;

            case "ภูมิแพ้":
                Requiremed1.text = "Dextromethorphan ยาแก้ไอ(แบบไม่มีเสมหะ)";
                Requiremed2.text = "Cholpheniramine ยาแก้แพ้(ช่วยลดน้ำมูกได้ดี)";
                Requiremed3.text = "Paracetamol ยาแก้ปวดลดไข้";
                Requiremed4.text = "";

                Requiremedlist.Add(Requiremed1.text);
                Requiremedlist.Add(Requiremed2.text);
                Requiremedlist.Add(Requiremed3.text);

                createMedicineTxt();
                break;
        }
    }
    void createMedicineTxt()
    {
        List<string> recievemed = Patient.GetComponent<Profile>().RecievedMedicine;
        for (int i = 0; i < recievemed.Count; i++)
        {
            GameObject newtxt = Instantiate(MedicineTxtTocreate, TextboxareaofMedicine.transform.GetComponent<RectTransform>());
            if (Requiremedlist.Contains(recievemed[i]))
            {
                newtxt.GetComponent<TMP_Text>().text = recievemed[i];
                newtxt.GetComponent<TMP_Text>().color = new Color32(100, 172, 51, 255); //GREEN
            }
            else
            {
                newtxt.GetComponent<TMP_Text>().text = recievemed[i];
                newtxt.GetComponent<TMP_Text>().color = new Color32(214, 75, 75, 255); //RED
            }
            
        }
    }
    public void getemotion(GameObject Patient)
    {
        float EmotionScore = Patient.GetComponent<PatientsEmotional>().EmotionScore;

        if(EmotionScore > 65)
        {
            EmotionImage.GetComponent<Image>().sprite = HappyFace;
        }
        if (EmotionScore < 65 && EmotionScore > 40)
        {
            EmotionImage.GetComponent<Image>().sprite = BoredFace;
        }
        if (EmotionScore < 40 && EmotionScore > 20)
        {
            EmotionImage.GetComponent<Image>().sprite = AngryFace;
        }
        if (EmotionScore < 20)
        {
            EmotionImage.GetComponent<Image>().sprite = MadFace;
        }
    }
    public void getPatient(GameObject patient)
    {
        Patient = patient;
        getemotion(patient);
        getinfo();
        getPlayerPlayInfo();
        getMedicineInformation();
        Name.text = patient.name;
        BoxName.text = patient.name;
        Sprite newpic = Patient.GetComponent<Profile>().MyPicture;
        Profile.sprite = newpic;
        SmallProfile.sprite = newpic;
    }
}
