using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameSy : MonoBehaviour
{
    MedicBedBehavior medicbed;
    [SerializeField]
    Slider Slidbar;
    [SerializeField]
    GameObject MinigamePanel, Sy,Whole;
    [SerializeField]
    Sprite Defaultsy, FullSy;
    [SerializeField]
    Image fill;

    bool clicked, plus;
    bool done;
    bool stop;
    public Vector3 offset;
    float holdtime;
    float stopvalue;
    string stage;

    int recievemed;
    private void Awake()
    {
        plus = true;
        stop = false;
        Slidbar.value = 0;
        Slidbar.maxValue = 60;
        recievemed = 0;
        Sy.GetComponent<Image>().sprite = Defaultsy;
        Sy.gameObject.SetActive(true);
    }
    private void OnEnable()
    {
        plus = true;
        stop = false;
        Slidbar.value = 0;
        Slidbar.maxValue = 60;
        recievemed = 0;
        Sy.GetComponent<Image>().sprite = Defaultsy;
        Sy.gameObject.SetActive(true);
    }
    private void Start()
    {
        medicbed = MedicBedBehavior.Medicbed;
    }
    void Update()
    {
        if (MinigamePanel.activeInHierarchy)
        {
            if (!stop)
            {
                checkvalue();
                checkclicked();
                checkValue();
                checkrelease();
                if (clicked)
                {
                    if (plus)
                    {
                        Slidbar.value += 20 * Time.deltaTime;
                    }
                    if (!plus)
                    {
                        Slidbar.value -= 20 * Time.deltaTime;
                    }
                }
                else
                {
                    Slidbar.value -= 20 * Time.deltaTime;
                }
            }
            else
            {
                Slidbar.value = stopvalue;
            }
        }
        Sy.transform.position = Input.mousePosition + new Vector3(210,220);
    }
    void checkrelease()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (done)
            {
                stop = true;
                stopvalue = Slidbar.value;
                done = false;
                Invoke("turnoffpanel", 0.5f);
            }
        }
    }
    void checkclicked()
    {
        if (Input.GetMouseButton(0))
        {
            clicked = true;
        }
        else
        {
            clicked = false;
        }
    }
    void checkValue()
    {
        if (Slidbar.value == 0)
        {
            plus = true;
        }
        if (Slidbar.value == 60)
        {
            plus = false;
        }
    }
    void checkvalue()
    {
        if(Slidbar.value > 40.5f)
        {
            done = false;
        }
        else if (Slidbar.value <30f)
        {
            done = false;
        }
        else
        {
            done = true;
        }
    }
    void turnoffpanel()
    {
        stop = false;
        Slidbar.value = 0;
        Sy.GetComponent<Image>().sprite = FullSy;
        PlayerPrefs.SetString("currenttool", "FullSy");
        MinigamePanel.SetActive(false);
    }
    void turnoffWholePanel()
    {
        if(medicbed.Patient.GetComponent<PatientsQuestData>().TakeAmoxleft == 0)
        {
            Whole.SetActive(false);
            PlayerPrefs.SetString("MiniGameMode", "");
        }
    }
    public void takemedicine()
    {
        Sy.GetComponent<Image>().sprite = Defaultsy;
        PlayerPrefs.SetString("currenttool", "EmpthySy");

        if (PlayerPrefs.GetInt("Med") == 1)
        {
            if (medicbed.Patient.GetComponent<PatientsQuestData>().Takemed1 != 0)
            {
                medicbed.Patient.GetComponent<PatientsQuestData>().Takemed1 = 0;
                medicbed.Patient.GetComponent<PatientsQuestData>().TakeAmoxleft -= 1;
            }
        }
        else if (PlayerPrefs.GetInt("Med") == 2)
        {
            if (medicbed.Patient.GetComponent<PatientsQuestData>().Takemed2 != 0)
            {
                medicbed.Patient.GetComponent<PatientsQuestData>().Takemed2 = 0;
                medicbed.Patient.GetComponent<PatientsQuestData>().TakeAmoxleft -= 1;
            }
        }
        Invoke("turnoffWholePanel", 0.5f);
    }
}
