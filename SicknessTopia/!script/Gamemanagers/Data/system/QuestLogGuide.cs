using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestLogGuide : MonoBehaviour
{
    public static QuestLogGuide QuestBlockController;

    [SerializeField]
    GameObject QuestLogBlock,PatientImgae;
    [SerializeField]
    TMP_Text HeadindGuid;
    [SerializeField]
    Sprite DoneQuestBlock, NormalQuestBlock;
    [SerializeField]
    Sprite YelloGuy, PinkLady, BlueLady, SupStar, SurfBoy, RedLady;
    [SerializeField]
    GameObject blog,quest;
    [SerializeField]
    Transform Hisroompos, DocRoom, Xray, Med, PatientRoom, Lab, Emergency,emergencyMed;
    [SerializeField]    
    GameObject sign;

    GameObject Patient;


    string Disease;
    private void Awake()
    {
        QuestBlockController = this;
    }
    public void updateQuestBoard(GameObject patient)
    {
        Patient = patient;
        VerifiedPatientProfile(patient);
        QuestLogBlock.SetActive(true);
    }
    public void CloseQuestBlock()
    {
        QuestLogBlock.SetActive(false);
    }
    public void CreateEmergencyCase(GameObject patient)
    {
         createquest("รักษาแผล", patient);
         createquest("จ่ายยารักษาแผล", patient);
    }
    void VerifiedPatientProfile(GameObject patient)
    {
        int ID = patient.GetComponent<Profile>().PatientsPersonalize;

        switch (ID)
        {
            case 1 :
                PatientImgae.GetComponent<Image>().sprite = YelloGuy;
                break;
            case 2:
                PatientImgae.GetComponent<Image>().sprite = PinkLady;
                break;
            case 3:
                PatientImgae.GetComponent<Image>().sprite = BlueLady;
                break;
            case 4:
                PatientImgae.GetComponent<Image>().sprite = SupStar;
                break;
            case 5:
                PatientImgae.GetComponent<Image>().sprite = SurfBoy;
                break;
            case 6:
                PatientImgae.GetComponent<Image>().sprite = RedLady;
                break;
        }
    }

    public void createquest(string qsttxt,GameObject Patient)
    {
        GameObject newquest = Instantiate(quest, blog.transform.GetComponent<RectTransform>());
        TMP_Text questtxt = newquest.GetComponentInChildren<TMP_Text>();
        questtxt.text = qsttxt;

        newquest.transform.parent = blog.transform;
        GameObject Sign = null;

        switch (qsttxt)
        {
            case "ทำประวัติ":
                if (Patient.GetComponent<PatientsQuestData>().OrdinaryQuestLeft <= 0)
                {
                    newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                }
                else
                {
                    Sign = Instantiate(sign, Hisroompos);
                }
                break;
            case "ตรวจร่างกาย":
                if (Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft <= 0)
                {
                    newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                }
                else
                {
                    Sign = Instantiate(sign, DocRoom);
                }
                break;
            case "จ่ายยา":
                if(Patient.GetComponent<Profile>().isspecial)
                {
                    if (Patient.GetComponent<PatientsQuestData>().Takemedicineleft <= 0)
                    {
                        newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                    }
                    else
                    {
                        Sign = Instantiate(sign, emergencyMed);
                    }
                }
                else
                {
                    if (Patient.GetComponent<PatientsQuestData>().Takemedicineleft <= 0)
                    {
                        newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                    }
                    else
                    {
                        Sign = Instantiate(sign, Med);
                    }
                }
                break;
            case "เอ็กส์เรย์ปอด":
                if (Patient.GetComponent<PatientsQuestData>().Xrayleft <= 0)
                {
                    newquest.GetComponent<Image>().sprite = DoneQuestBlock;

                }
                else
                {
                    Sign = Instantiate(sign, Xray);
                }
                break;
            case "ตรวจเสมหะ":
                if (Patient.GetComponent<PatientsQuestData>().LiquidTestleft <= 0)
                {
                    newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                    
                }
                else
                {
                     Sign = Instantiate(sign,PatientRoom);
                }
                break;
            case "ตรวจสารที่แพ้":
                if (Patient.GetComponent<PatientsQuestData>().Skintestleft <= 0)
                {
                    newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                    
                }
                else
                {
                    Sign = Instantiate(sign,PatientRoom);
                }
                break;
            case "นำตัวอย่างไปเข้าแลป":
                if (Patient.GetComponent<PatientsQuestData>().lableft <= 0)
                {
                    newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                }
                else
                {
                    Sign = Instantiate(sign,Lab);
                }
                break;
            case "ฉีดยา":
                if (Patient.GetComponent<PatientsQuestData>().TakeAmoxleft <= 0)
                {
                    newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                }
                else
                {
                    Sign = Instantiate(sign,PatientRoom);
                }
                break;


            case "รักษาแผล":
                if (Patient.GetComponent<SpecialProfile>().TreatditionLeft <= 0)
                {
                    newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                }
                else
                {
                    Sign = Instantiate(sign, Emergency);
                }
                break;
            case "จ่ายยารักษาแผล":
                if (Patient.GetComponent<PatientsQuestData>().Takemedicineleft <= 0)
                {
                    newquest.GetComponent<Image>().sprite = DoneQuestBlock;
                }
                else
                {
                    Sign = Instantiate(sign, emergencyMed);
                }
                break;
        }

        newquest.GetComponent<QuestSignBehavior>().sign = Sign;
    }
    public void CreateSpecialQuest(GameObject patient)
    {
        string disease = GetDisease(patient);
        if (disease == "ยังไม่ได้วินิจฉัยโรคที่ป่วย")
        {
            if(patient.GetComponent<PatientsQuestData>().OrdinaryQuestLeft != 0)
            {
                createquest("ทำประวัติ", patient);
            }
            else
            {
                createquest("ทำประวัติ", patient);
                createquest("ตรวจร่างกาย", patient);
            }
            
        }
        else
        {
            switch (disease)
            {
                case "ไข้หวัดธรรมดา":
                    createquest("ทำประวัติ", patient);
                    createquest("ตรวจร่างกาย", patient);
                    createquest("จ่ายยา", patient);
                    break;

                case "ไข้หวัดคออักเสบ(เชื้อไวรัส)":
                    createquest("ทำประวัติ", patient);
                    createquest("ตรวจร่างกาย", patient);
                    createquest("จ่ายยา", patient);
                    break;

                case "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)":
                    createquest("ทำประวัติ", patient);
                    createquest("ตรวจร่างกาย", patient);
                    createquest("จ่ายยา", patient);
                    break;
                case "ไข้หวัดปอดอักเสบ":
                    createquest("ทำประวัติ", patient);
                    createquest("ตรวจร่างกาย", patient);
                    createquest("เอ็กส์เรย์ปอด", patient);
                    createquest("ตรวจเสมหะ", patient);
                    createquest("นำตัวอย่างไปเข้าแลป", patient);
                    createquest("ฉีดยา", patient);
                    createquest("จ่ายยา", patient);
                    break;

                case "ภูมิแพ้":
                    createquest("ทำประวัติ", patient);
                    createquest("ตรวจร่างกาย", patient);
                    createquest("ตรวจสารที่แพ้", patient);
                    createquest("นำตัวอย่างไปเข้าแลป", patient);
                    createquest("จ่ายยา", patient);
                    break;
            }
        }
    }

    string GetDisease(GameObject patient)
    {
        string disease;
        if (patient != null)
        {
            disease = patient.GetComponent<Profile>().PredictionDisease;
        }
        else
        {
            disease = "";
        }

        return disease;
    }
}
