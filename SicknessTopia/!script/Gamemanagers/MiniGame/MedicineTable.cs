using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MedicineTable : MonoBehaviour
{
    public static MedicineTable medictable;
    medicineRoomBehavior medicbed;
    EmergencyTable emermedictable;
    SoundManager sound;
    DayManagement dayManagement;

    [SerializeField]
    Image Images;
    [SerializeField]
    Sprite ID1, ID2, ID3, ID4, ID5, ID6, ID7, ID8, ID9,Empthy;
    [SerializeField]
    GameObject Medicineroom,P1, P2, P3, P4, P5, P6, P7, P8, P9;
    [SerializeField]
    GameObject confirmPanel,MedtxtTocreate,TextboxArea;
    int PotionID;
    GameObject selecedpotion;
    Vector3 mouse;

    public List<string> PotionsinBucket = new List<string>();
    private void Awake()
    {
        selecedpotion = null;
        medictable = this;
        medicbed = medicineRoomBehavior.MedicineRoomBehavior;
        emermedictable = EmergencyTable.emerbed;
    }
    private void Start()
    {
        sound = SoundManager.sound;
        dayManagement = DayManagement.daymanage;
    }
    private void Update()
    {
        checpotion();
        mouse = Input.mousePosition;
    }
    void checpotion()
    {
        switch (PotionID)
        {
            case 0:
                Images.sprite = Empthy;
                break;
            case 1:
                Images.sprite = ID1;
                break;
            case 2:
                Images.sprite = ID2;
                break;
            case 3:
                Images.sprite = ID3;
                break;
            case 4:
                Images.sprite = ID4;
                break;
            case 5:
                Images.sprite = ID5;
                break;
            case 6:
                Images.sprite = ID6;
                break;
            case 7:
                Images.sprite = ID7;
                break;
            case 8:
                Images.sprite = ID8;
                break;
            case 9:
                Images.sprite = ID9;
                break;
        }
    }
    public void onexithower()
    {
        PotionID = 0;
    }
    public void Id1()
    {
        PotionID = 1;
    }
    public void Id2()
    {
        PotionID = 2;
    }
    public void Id3()
    {
        PotionID = 3;
    }
    public void Id4()
    {
        PotionID = 4;
    }
    public void Id5()
    {
        PotionID = 5;
    }
    public void Id6()
    {
        PotionID = 6;
    }
    public void Id7()
    {
        PotionID = 7;
    }
    public void Id8()
    {
        PotionID = 8;
    }
    public void Id9()
    {
        PotionID = 9;
    }

    public void clickbin()
    {
        P1.GetComponent<PotionBehavior>().Reset();
        P2.GetComponent<PotionBehavior>().Reset();
        P3.GetComponent<PotionBehavior>().Reset();
        P4.GetComponent<PotionBehavior>().Reset();
        P5.GetComponent<PotionBehavior>().Reset();
        P6.GetComponent<PotionBehavior>().Reset();
        P7.GetComponent<PotionBehavior>().Reset();
        P8.GetComponent<PotionBehavior>().Reset();
        P9.GetComponent<PotionBehavior>().Reset();
        PotionsinBucket.Clear();
    } 
    public void clickbusket()
    {
        confirmPanel.SetActive(true);
        for (int i = 0; i < PotionsinBucket.Count; i++)
        {
            createconfirmmedicine(PotionsinBucket[i]);
        }
    }
    public void onclickYes()
    {
        sound.PlayCheckout();
        GameObject[] Createdtxt = GameObject.FindGameObjectsWithTag("CreatedTxt");
        for (int i = 0; i < Createdtxt.Length; i++)
        {
            Destroy(Createdtxt[i]);
        }
        medicbed.CheckoutPatient(PotionsinBucket);
        confirmPanel.SetActive(false);
        clickbin();
        Medicineroom.SetActive(false);
        this.gameObject.SetActive(false);

        if (dayManagement.dayend)
        {
            if(dayManagement.Day == 0)
            {
                if (dayManagement.todayTreat >= 9)
                {
                    dayManagement.showEndDayPanel();
                }
            }
            else
            {
                dayManagement.showEndDayPanel();
            }
        }
    }
    public void onclickEmerYes()
    {
        sound.PlayCheckout();
        GameObject[] Createdtxt = GameObject.FindGameObjectsWithTag("CreatedTxt");
        for (int i = 0; i < Createdtxt.Length; i++)
        {
            Destroy(Createdtxt[i]);
        }
        emermedictable.CheckoutPatient(PotionsinBucket);
        confirmPanel.SetActive(false);
        clickbin();
        Medicineroom.SetActive(false);
        this.gameObject.SetActive(false);

        if (dayManagement.dayend)
        {
            if (dayManagement.Day == 0)
            {
                if (dayManagement.todayTreat >= 9)
                {
                    dayManagement.showEndDayPanel();
                }
            }
            else
            {
                dayManagement.showEndDayPanel();
            }
        }
    }
    public void Exit()
    {
        GameObject[] Createdtxt = GameObject.FindGameObjectsWithTag("CreatedTxt");
        for (int i = 0; i < Createdtxt.Length; i++)
        {
            Destroy(Createdtxt[i]);
        }
        clickbin();
        this.gameObject.SetActive(false);
    }
    public void onclickno()
    {
        GameObject[] Createdtxt = GameObject.FindGameObjectsWithTag("CreatedTxt");
        for (int i = 0; i < Createdtxt.Length; i++)
        {
            Destroy(Createdtxt[i]);
        }
        confirmPanel.SetActive(false);
    }
    public void createconfirmmedicine(string MedicineName)
    {
        GameObject newtext = Instantiate(MedtxtTocreate,TextboxArea.transform.GetComponent<RectTransform>());
        newtext.GetComponent<TMP_Text>().text = MedicineName;
    }
}
