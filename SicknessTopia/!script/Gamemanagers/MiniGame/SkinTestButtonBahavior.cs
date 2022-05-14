using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinTestButtonBahavior : MonoBehaviour
{
    MedicBedBehavior medicBed;
    string currenttool;
    public string currentstage;
    int clicked;
    bool faded;
    [SerializeField]
    Image Point,rash,circle;
    [SerializeField]
    GameObject MinigamePanel;
    Color mycolor;
    string whatisthisliquid;

    GameObject Patient;
    private void Awake()
    {
        currentstage = "Lined";
    }
    private void Start()
    {
        medicBed = MedicBedBehavior.Medicbed;
    }
    private void Update()
    {
        currenttool = PlayerPrefs.GetString("currenttool");
        if (clicked >=3) 
        {
            faded = true;
        }
        if (faded)
        {
            mycolor = new Color32(1, 1, 1, 1);
            Point.GetComponent<Image>().color -= mycolor* Time.deltaTime*50;
            if(Point.GetComponent<Image>().color.a <= 0)
            {
                Patient.GetComponent<PatientsQuestData>().Skintestleft = 0;
                string allergy = Patient.GetComponent<Profile>().allergy;
                if(allergy == whatisthisliquid)
                {
                    rash.gameObject.SetActive(true);
                    Patient.GetComponent<Profile>().allergytest = allergy;
                    Patient.GetComponent<PatientsQuestData>().Skintestleft = 0;
                }
            }
        }
    }
    public void onclick()
    {
        switch (currentstage)
        {
            case "Lined":
                switch (currenttool)
                {
                    case "นมวัว":
                        whatisthisliquid = currenttool;
                        mycolor = new Color32(216, 231,232,255);
                        Point.GetComponent<Image>().color = mycolor;
                        Point.gameObject.SetActive(true);
                        circle.gameObject.SetActive(false);
                        currentstage = "Droped";
                        break;
                    case "อาหารทะเล":
                        whatisthisliquid = currenttool;
                        mycolor = new Color32(115, 181, 237,255);
                        Point.GetComponent<Image>().color = mycolor;
                        Point.gameObject.SetActive(true);
                        circle.gameObject.SetActive(false);
                        currentstage = "Droped";
                        break;
                    case "เกสรหญ้า":
                        whatisthisliquid = currenttool;
                        mycolor = new Color32(140, 191, 147,255);
                        Point.GetComponent<Image>().color = mycolor;
                        Point.gameObject.SetActive(true);
                        circle.gameObject.SetActive(false);
                        currentstage = "Droped";
                        break;
                    case "เชื้อรา":
                        whatisthisliquid = currenttool;
                        mycolor = new Color32(171, 127, 212,255);
                        Point.GetComponent<Image>().color = mycolor;
                        Point.gameObject.SetActive(true);
                        circle.gameObject.SetActive(false);
                        currentstage = "Droped";
                        break;
                    case "ไข่":
                        whatisthisliquid = currenttool;
                        mycolor = new Color32(232, 211, 185,255);
                        Point.GetComponent<Image>().color = mycolor;
                        Point.gameObject.SetActive(true);
                        circle.gameObject.SetActive(false);
                        currentstage = "Droped";
                        break;
                    case "ไรฝุ่น":
                        whatisthisliquid = currenttool;
                        mycolor = new Color32(163, 163, 163,255);
                        Point.GetComponent<Image>().color = mycolor;
                        Point.gameObject.SetActive(true);
                        circle.gameObject.SetActive(false);
                        currentstage = "Droped";
                        break;
                }
            break;

            case "Droped":
                if (currenttool == "Niddle")
                {
                    clicked++;
                }
                break;
        }
    }

    private void Reset()
    {
        clicked = 0;
        currentstage = "Lined";
        rash.gameObject.SetActive(false);
        faded = false;
    }
    private void OnEnable()
    {
        medicBed = MedicBedBehavior.Medicbed;
        Patient = medicBed.Patient;
        Reset();
    }
    private void OnDisable()
    {
        Reset();
    }
}
