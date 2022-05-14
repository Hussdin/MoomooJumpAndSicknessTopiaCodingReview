using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientsEmotional : MonoBehaviour
{
    public float EmotionScore;
    public string Emotion;

    [SerializeField]
    GameObject EmotionImage;
    [SerializeField]
    Sprite HappyFace, BoredFace, AngryFace, MadFace;
    private void Awake()
    {
        EmotionScore = 100;
        EmotionalLevelCheck();
        InvokeRepeating("delayemotion", 0, 60);
    }
    private void Update()
    {
        EmotionScore -= 0.1f * Time.deltaTime;
    }
    public void AddEmotionalScore(int score)
    {
        if (EmotionScore < 100)
        {
            EmotionScore += score;
            EmotionalLevelCheck();
        }
    }
    public void RemoveEmotionalScore(int score)
    {
         EmotionScore -= score;
         EmotionalLevelCheck();
    }
    void EmotionalLevelCheck()
    {
        switch (EmotionScore)
        {
            case >80:
                Emotion = "Happy";
                EmotionImage.GetComponent<SpriteRenderer>().sprite = HappyFace;
                break;
            case > 60:
                Emotion = "Bored";
                EmotionImage.GetComponent<SpriteRenderer>().sprite = BoredFace;
                break;
            case > 40:
                Emotion = "Angry";
                EmotionImage.GetComponent<SpriteRenderer>().sprite = AngryFace;
                break;
            case > 20:
                Emotion = "Mad";
                EmotionImage.GetComponent<SpriteRenderer>().sprite = MadFace;
                break;
        }
    }
  
    void delayemotion()
    {
        if (EmotionImage.activeInHierarchy)
        {
            EmotionImage.SetActive(false);
        }
        else
        {
            EmotionImage.SetActive(true);
        }
       
    }

    public void checkMethod(GameObject Patient)
    {
        if(Patient.GetComponent<Profile>().PredictionDisease == "ยังไม่ได้วินิจฉัยโรคที่ป่วย")
        {
            RemoveEmotionalScore(50);
        }
        if (Patient.GetComponent<PatientsQuestData>().OrdinaryQuestLeft !=0)
        {
            RemoveEmotionalScore(20);
        }
        if(Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft != 0)
        {
            RemoveEmotionalScore(20);
        }

        checkmethodleft(); 
        checkmed(Patient);
        EmotionalLevelCheck();
    }

    public List<string> whaticando = new List<string>();
    public List<string> whatmedicantake = new List<string>();
    public void removemethod(string item)
    {
        if (whaticando.Contains(item))
        {
            whaticando.Remove(item);
        }
    }
    public void checkwhatcando(GameObject Patient)
    {
            string disease = Patient.GetComponent<Profile>().Disease;
            switch (disease)
            {
                case "ไข้หวัดธรรมดา":
                    whaticando.Add("จ่ายยาตามอาการ");
                    break;

                case "ไข้หวัดคออักเสบ(เชื้อไวรัส)":
                    whaticando.Add("จ่ายยาตามอาการ");
                    break;

                case "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)":
                    whaticando.Add("จ่ายยาตามอาการ");
                    break;

                case "ไข้หวัดปอดอักเสบ":
                    whaticando.Add("เอ็กส์เรย์ปอด");
                    whaticando.Add("ตรวจหาเชื้อจากเสมหะ");
                    whaticando.Add("นำตัวอย่างไปเข้าแลป");
                    whaticando.Add("ฉีดยา Amoxicillin");
                    whaticando.Add("จ่ายยาตามอาการ");
                    break;

                case "ภูมิแพ้":
                    whaticando.Add("ตรวจสารที่แพ้");
                    whaticando.Add("นำตัวอย่างไปเข้าแลป");
                    whaticando.Add("จ่ายยาตามอาการ");
                    break;
            }
    }
    public void checmedcantake(GameObject Patient)
    {
        if (Patient.GetComponent<SpecialProfile>() != null)
        {
            whatmedicantake.Add("Paracetamol ยาแก้ปวดลดไข้");
            whatmedicantake.Add("Ibuprofen ยาแก้อักเสบ ");
        }
        else
        {
            string disease = Patient.GetComponent<Profile>().Disease;
            switch (disease)
            {
                case "ไข้หวัดธรรมดา":
                    whatmedicantake.Add("Dextromethorphan ยาแก้ไอ(แบบไม่มีเสมหะ)");
                    whatmedicantake.Add("Paracetamol ยาแก้ปวดลดไข้");
                    whatmedicantake.Add("Cholpheniramine ยาแก้แพ้(ช่วยลดน้ำมูกได้ดี)");
                    break;

                case "ไข้หวัดคออักเสบ(เชื้อไวรัส)":
                    whatmedicantake.Add("Carbocysteine ยาแก้ไอ (แบบมีเสมหะ)");
                    whatmedicantake.Add("Paracetamol ยาแก้ปวดลดไข้");
                    break;

                case "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)":
                    whatmedicantake.Add("Amoxicillin ยาปฏิชีวนะ");
                    whatmedicantake.Add("Carbocysteine ยาแก้ไอ (แบบมีเสมหะ)");
                    whatmedicantake.Add("Paracetamol ยาแก้ปวดลดไข้");
                    break;

                case "ไข้หวัดปอดอักเสบ":
                    whatmedicantake.Add("Amoxicillin ยาปฏิชีวนะ");
                    whatmedicantake.Add("Paracetamol ยาแก้ปวดลดไข้");
                    break;

                case "ภูมิแพ้":
                    whatmedicantake.Add("Dextromethorphan ยาแก้ไอ(แบบไม่มีเสมหะ)");
                    whatmedicantake.Add("Cholpheniramine ยาแก้แพ้(ช่วยลดน้ำมูกได้ดี)");
                    whatmedicantake.Add("Paracetamol ยาแก้ปวดลดไข้");
                    break;
            }
        }
        
    }
    void checkmethodleft()
    {
        int Methodleft = whaticando.Count;
        int dispointpermethod = 10;
        int totaldispoint = dispointpermethod * Methodleft;

        RemoveEmotionalScore(totaldispoint);
        Debug.Log("method " + totaldispoint);
    }

    void checkmed(GameObject patient)
    {
        int totaldispoint = 0;
        List<string> patientmed = patient.GetComponent<Profile>().RecievedMedicine;
        int count = patientmed.Count;
        for (int i = 0; i < count; i++)
        {
            if (!whatmedicantake.Contains(patientmed[i]))
            {
                totaldispoint += 10;
            }
        }
        RemoveEmotionalScore(totaldispoint);
        Debug.Log("med " + totaldispoint);
    }
}
