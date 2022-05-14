using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighMeter : MonoBehaviour
{
    ProgressBlog progressblog;
    SoundManager sound;

    public GameObject Patient;
    float staytime = 0;
    public bool pressed, canpress;
    bool alreadyshow;
    public bool stay;
    public float requirestaytime;
    [SerializeField]
    Image fillimage;
    [SerializeField]
    GameObject pos;

    private void Start()
    {
        progressblog = ProgressBlog.progressBlog;
        sound = SoundManager.sound;
        staytime = 0;
    }
    private void Update()
    {
        if (canpress)
        {
            if (Input.GetKeyDown("e"))
            {
                pressed = true;
            }
        }
        working();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Patient != null)
        {

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
            canpress = true;
            if (pressed)
            {
                progressblog.UpdateBoard("High");
                other.GetComponent<PlayerBehaviorControll>().losePatient();
                Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(pos.transform.position, pos.transform.rotation);
                stay = true;
                sound.PlayLoading();
                pressed = false;
            }
            else
            {
                if (!alreadyshow)
                {
                    other.GetComponent<PlayerBehaviorControll>().showEIcon();
                    alreadyshow = true;

                }  
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            Patient = null;
            alreadyshow = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerBehaviorControll>().closeEIcon();
        }

        progressblog.UpdateBoard("");
        canpress = false;
    }

    void working()
    {
        if (stay)
        {
            staytime += Time.deltaTime;
            if (staytime >= requirestaytime)
            {
                randomhigh(Patient);
                Reset();
            }
            fillimage.fillAmount = staytime / requirestaytime;
        }
    }
    void randomhigh(GameObject patient)
    {
        if (patient.GetComponent<Profile>().high ==0)
        {
            patient.GetComponent<Profile>().high = Random.Range(160, 180);
            patient.GetComponent<Profile>().weight = Random.Range(47, 70);
            patient.GetComponent<PatientsQuestData>().OrdinaryQuestLeft -= 2;
            patient.GetComponent<PatientBehavior>().showdoneicon();
        }
         
    }
    private void Reset()
    {
        sound.LoadingSound.Stop();
        stay = false;
        staytime = 0;
        fillimage.fillAmount = staytime / requirestaytime;
    }
}
