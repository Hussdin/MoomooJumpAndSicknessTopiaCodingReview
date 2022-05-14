using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBPMachine : MonoBehaviour
{
    ProgressBlog progressblog;
    SoundManager sound;

    public GameObject Patient;
    float staytime = 0;
    bool pressed,canpress;

    bool stay,alreadyshow;
    public float requirestaytime;
    [SerializeField]
    Image fillimage;
    [SerializeField]
    GameObject pos;

    private void Start()
    {
        progressblog = ProgressBlog.progressBlog;
        staytime = 0;
        sound = SoundManager.sound;
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
        if(other.gameObject.CompareTag("Player")&&Patient != null)
        {
            canpress = true;
            if (pressed)
            {
                progressblog.UpdateBoard("BP");
                other.GetComponent<PlayerBehaviorControll>().losePatient();
                Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(pos.transform.position, pos.transform.rotation);
                sound.PlayLoading();
                stay = true;
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
                randombp(Patient);
                Reset();
            }
            fillimage.fillAmount = staytime / requirestaytime;
        }
    }
    void randombp(GameObject Patient)
    {
        if (Patient.GetComponent<Profile>().bp == "")
        {
            Patient.GetComponent<Profile>().bp = " " + Random.Range(110, 129) + " : " + Random.Range(78, 86);
            Patient.GetComponent<PatientsQuestData>().OrdinaryQuestLeft -= 1;
            Patient.GetComponent<PatientBehavior>().showdoneicon();
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
