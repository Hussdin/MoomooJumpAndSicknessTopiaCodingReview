using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public static Profile profile;
    public float age, weight, high,temp;
    public string names,bp,Gender,BG,MA;
    public bool knowshigh,knowsweight,knowsbp;
    public string Disease;
    public int PatientsPersonalize;
    public string PredictionDisease;
    public int Que;
    public string s1, s2, s3, s4, s5;
    int knowsymptomcount;
    public string allergy,allergytest;
    char[] character = { 'b', 'c', 'd', 'f', 'g','h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'};
    char[] sara = { 'a', 'e', 'i', 'o', 'u' };
    public bool isspecial;
    public List<string> RecievedMedicine = new List<string>();

    float[] SpawnRates;
    public CurrentGameDatatoconfig data;
    LevelDesignAdjustment LVadjust;
    FirstDayManager firstday;

    public Sprite MyPicture;

    private void Awake()
    {
        profile = this;
        knowshigh = false;
        PredictionDisease = "ยังไม่ได้วินิจฉัยโรคที่ป่วย";
        this.gameObject.name = randomname();
        randomFixInformation();
    }
    private void Start()
    {
        data = CurrentGameDatatoconfig.savegame;
        LVadjust = LevelDesignAdjustment.LvAdjust;
        firstday = FirstDayManager.firstday;
        checkGameMode();

    }
    public virtual void checkGameMode()
    {
        int day = data.day;
        if (day == 0)
        {
            RandomdiseaseforTestMode();
            this.gameObject.GetComponent<PatientsEmotional>().checkwhatcando(this.gameObject);
            this.gameObject.GetComponent<PatientsEmotional>().checmedcantake(this.gameObject);
        }
        else
        {
            RandomDisease(0.4f, 0.6f, 0.8f, 0.9f, 1f);
            this.gameObject.GetComponent<PatientsEmotional>().checkwhatcando(this.gameObject);
            this.gameObject.GetComponent<PatientsEmotional>().checmedcantake(this.gameObject);
        }
    }
    void randomageandBloodGroup(string condition)
    {
        string[] BGinformation = { "A","AB","B","O"};
        int num = Random.Range(0,BGinformation.Length);
        BG = BGinformation[num];
        if(condition == "Young")
        {
            age = Random.Range(20, 50);
        }
        else
        {
            age = Random.Range(50, 70);
        }
    }
    void randomFixInformation()
    {
        switch (PatientsPersonalize)
        {
            default:
                break;
            case 1:
                randomageandBloodGroup("Young");
                Gender = "ชาย";

                break;
            case 2:
                randomageandBloodGroup("old");
                Gender = "หญิง";
                break;
            case 3:
                randomageandBloodGroup("old");
                Gender = "ชาย";
                break;
            case 4:
                randomageandBloodGroup("Young");
                Gender = "หญิง";
                break;
            case 5:
                randomageandBloodGroup("Young");
                Gender = "ชาย";
                break;
            case 6:
                randomageandBloodGroup("Young");
                Gender = "หญิง";
                break;
            case 7:
                randomageandBloodGroup("Young");
                Gender = "หญิง";
                break;
            case 8:
                randomageandBloodGroup("Young");
                Gender = "ชาย";
                break;
            case 9:
                randomageandBloodGroup("Young");
                Gender = "ชาย";
                break;
            case 10:
                randomageandBloodGroup("Young");
                Gender = "ชาย";
                break;
        }
    }
    string randomname()
    {
        string PatientName = character[Random.Range(0, character.Length)].ToString().ToUpper();
        PatientName = PatientName+ sara[Random.Range(0, sara.Length)].ToString();
        PatientName = PatientName + character[Random.Range(0, character.Length)].ToString();
        PatientName = PatientName + sara[Random.Range(0, sara.Length)].ToString();
        PatientName = PatientName + character[Random.Range(0, character.Length)].ToString();

        PatientName = PatientName +" "+ character[Random.Range(0, character.Length)].ToString().ToUpper();
        PatientName = PatientName + sara[Random.Range(0, sara.Length)].ToString();
        PatientName = PatientName + character[Random.Range(0, character.Length)].ToString();
        PatientName = PatientName + sara[Random.Range(0, sara.Length)].ToString();
        PatientName = PatientName + character[Random.Range(0, character.Length)].ToString();

        return PatientName;
    }
    string randomallergy()
    {
        string allergy;
        int Ran = Random.Range(1,7);
        switch (Ran)
        {
            default:
                allergy = "";
                break;
            case 1:
                allergy = "นมวัว";
                break;
            case 2:
                allergy = "อาหารทะเล";
                break;
            case 3:
                allergy = "เกสรหญ้า";
                break;
            case 4:
                allergy = "เชื้อรา";
                break;
            case 5:
                allergy = "ไข่";
                break;
            case 6:
                allergy = "ไรฝุ่น";
                break;
        }
        return allergy;
    }
    public virtual void RandomDisease(float SR1, float SR2, float SR3, float SR4,float SR5)
    {
        float chance = Random.value;
        if(chance < SR1)
        {
            Disease = "ไข้หวัดธรรมดา";
        }
        else if(chance >SR1 && chance < SR2)
        {
            Disease = "ไข้หวัดคออักเสบ(เชื้อไวรัส)";
        }
        else if(chance> SR2 && chance < SR4)
        {
            Disease = "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)";
        }
        else if(chance > SR3 && chance < SR5)
        {
            Disease = "ไข้หวัดปอดอักเสบ";
        }
        else if (chance > SR5)
        {
            Disease = "ภูมิแพ้";
            allergy = randomallergy();
        }

    }
    public virtual void RandomdiseaseforTestMode()
    {
        Disease = firstday.getdisease("Normal");
        if(Disease == "ภูมิแพ้")
        {
            allergy = randomallergy();
        }
    }

    public virtual void RandomSpecialdiseaseforTestMode()
    {
        Disease = firstday.getdisease("Special");
    }

    List<string> recievesym = new List<string>();
    public void recieveSymptom(string sym)
    {
        if (!recievesym.Contains(sym))
        {
            recievesym.Add(sym);
            setsymtom(sym);
        }
    }
    void setsymtom(string sym)
    {
        switch (recievesym.Count)
        {
                case 1:
                    s1 = sym; 
                    break;
                case 2:
                    s2 = sym;
                    break;
                case 3:
                    s3 = sym;
                    break;
                case 4:
                    s4 = sym;
                    break;
                case 5:
                    s5 = sym;
                recievesym.Clear();
                    break;    
         }
    }
}
