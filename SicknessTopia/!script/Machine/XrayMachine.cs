using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XrayMachine : MonoBehaviour
{
    ProgressBlog progressblog;
    Animator anim;
    SoundManager sound;

    [SerializeField]
    GameObject Startpos, EndPos, Bed,bedpos;

    string disease;
    [SerializeField]
    Image Lung;
    [SerializeField]
    Sprite normalLung, DiseaseLung,Defaultxray;

    bool stay,press,starting;
    float staytime;
    public float requirestaytime;
    GameObject Patient, Player;

    [SerializeField]
    Image fillImage;
    [SerializeField]
    GameObject pos,xraypanel;

    private void Start()
    {
        progressblog = ProgressBlog.progressBlog;
        staytime = 0;
        anim = GetComponent<Animator>();
        sound = SoundManager.sound;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            progressblog.UpdateBoard("Xray");
            Player = other.gameObject;
            xraypanel.gameObject.SetActive(true);
            Player.GetComponent<PlayerBehaviorControll>().showEIcon();
        }
        if (other.gameObject.CompareTag("Patient"))
        {
            Patient = other.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Patient != null && other.gameObject.CompareTag("Player"))
        {
            if (press)
            {
                Player.GetComponent<PlayerBehaviorControll>().losePatient();
                Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(Startpos.transform.position, Startpos.transform.rotation);
                starting = true;
                press = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            stay = false;
            progressblog.UpdateBoard("");
            other.GetComponent<PatientBehavior>().closedoneicon();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<PlayerBehaviorControll>().closeEIcon();
            progressblog.UpdateBoard("");
            xraypanel.gameObject.SetActive(false);
        }
    }
    void startdoingXray()
    {
        if (starting)
        {
            if (Patient.GetComponent<PatientBehavior>().agent.remainingDistance == 0)
            {
                Patient.GetComponent<PatientBehavior>().telltostop();
                layinebed();
                playanimation();
                sound.PlayLoading();
                stay = true;
                starting = false;
            }
        } 
    }
    void layinebed()
    {
        Patient.transform.position = bedpos.transform.position;
        Patient.transform.rotation = bedpos.transform.rotation;
    }
    void xray()
    {
        disease = Patient.GetComponent<Profile>().Disease;
        if(disease == "ไข้หวัดปอดอักเสบ")
        {
            Lung.sprite = DiseaseLung;
            Patient.GetComponent<PatientsQuestData>().Xrayleft = 0;
            Patient.GetComponent<PatientsEmotional>().removemethod("เอ็กส์เรย์ปอด");
        }
        else
        {
            Lung.sprite = normalLung;
            Patient.GetComponent<PatientsQuestData>().Xrayleft = 0;
            Patient.GetComponent<PatientsEmotional>().removemethod("เอ็กส์เรย์ปอด");
        }

        Patient.transform.position = Startpos.transform.position;
        Patient.transform.rotation = Startpos.transform.rotation;
        sound.LoadingSound.Stop();
        sound.QuestDone.Play();
    }
 
    private void Update()
    {
        startdoingXray();
        checkpress();
        if (stay)
        {
            Patient.transform.position = bedpos.transform.position;
            staytime += Time.deltaTime;
            if (staytime >= requirestaytime)
            {
                xray();
            }
            fillImage.fillAmount = staytime / requirestaytime;
        }  
    }
    void checkpress()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            press = true;
        }
    }
    private void Reset()
    {
        sound.LoadingSound.Stop();
        stay = false;
        staytime = 0;
        fillImage.fillAmount = staytime / requirestaytime;
    }
    
    void playanimation()
    {
        anim.Play("Xray");
    }
    void setanimtofale()
    {
        anim.SetBool("On", false);
        Reset();
    }
    private void OnDisable()
    {
        Lung.sprite = Defaultxray;
    }
}
