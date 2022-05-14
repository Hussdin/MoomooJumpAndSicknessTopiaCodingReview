using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedicBedBehavior : MonoBehaviour
{
    public static MedicBedBehavior Medicbed;
    [SerializeField]
    GameObject Skintestpanel,Bedpos,BedBlog,WholePanel,AmoxPanel,AmoxMinigamePanel;

    public GameObject Player, Patient;

    bool ondoing;
    float staytime;
    public float requirestaytime;
    [SerializeField]
    Image fillImage;
    ProgressBlog progressBlog;

    bool stay;
    private void Awake()
    {
        Medicbed = this;
    }
    private void Start()
    {
        progressBlog = ProgressBlog.progressBlog;
        staytime = requirestaytime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player = other.gameObject;
            BedBlog.SetActive(true);
        }
        if (other.gameObject.CompareTag("Patient"))
        {
            Patient = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Patient != null)
        {
            stay = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BedBlog.SetActive(false);
        }
        if (other.gameObject.CompareTag("Patient"))
        {
            stay = false;
            Patient = null;
        }
    }
    public void onclickSkinTest()
    {
        if (Patient != null)
        {
            if (Skintestpanel.activeInHierarchy)
            {
                Skintestpanel.SetActive(false);
            }
            else
            {
                Player.GetComponent<PlayerBehaviorControll>().losePatient();
                Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(Bedpos.transform.position, Bedpos.transform.rotation);
                Invoke("openskintest", 1);
            }
        } 
    }
    public void onclickAmox()
    {
        if (Patient != null)
        {
            if (AmoxPanel.activeInHierarchy)
            {
                AmoxPanel.SetActive(false);
            }
            else
            {
                Player.GetComponent<PlayerBehaviorControll>().losePatient();
                Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(Bedpos.transform.position, Bedpos.transform.rotation);
                Invoke("openAmoxpanel", 1);
            }
        }
    }
    public void OnclickeMed1()
    {
        PlayerPrefs.SetInt("Med", 1);
        AmoxMinigamePanel.SetActive(true);
    }
    public void OnclickeMed2()
    {
        PlayerPrefs.SetInt("Med", 2);
        AmoxMinigamePanel.SetActive(true);
    }
    public void onclickExit()
    {
        WholePanel.SetActive(false);
    }
    public void onclickPickExample()
    {
        progressBlog.UpdateBoard("Liquid");
        Player.GetComponent<PlayerBehaviorControll>().losePatient();
        Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(Bedpos.transform.position, Bedpos.transform.rotation);
        if (stay)
        {
            ondoing = true;
        }

    }
    public void CommadPatientToBed()
    {
        Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(Bedpos.transform.position, Bedpos.transform.rotation);
    }
    void doneLiquidTest()
    {
        Patient.GetComponent<PatientBehavior>().showdoneicon();
        Patient.GetComponent<PatientsQuestData>().LiquidTestleft = 0;
    }
    void openskintest()
    {
        Skintestpanel.SetActive(true);
    }
    void openAmoxpanel()
    {
        AmoxPanel.SetActive(true);
        PlayerPrefs.SetString("MiniGameMode", "Amox");
    }
    private void Update()
    {
        if (ondoing)
        {
            staytime -= Time.deltaTime;
            if (staytime <= 0)
            {
                doneLiquidTest();
                Reset();
            }
            fillImage.fillAmount = staytime / requirestaytime;
        }
    }

    private void Reset()
    {
        stay = false;
        ondoing = false;
        staytime = requirestaytime;
        fillImage.fillAmount = staytime / requirestaytime;
    }
}
