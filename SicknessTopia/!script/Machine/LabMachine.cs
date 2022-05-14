using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabMachine : MonoBehaviour
{
    SoundManager sound;
    ProgressBlog progressblog;
    [SerializeField]
    GameObject Patient, Player,waitpos,done;
    [SerializeField]
    Image fillImage;
    bool stay;
    float staytime;
    public float requirestaytime;
    private void Start()
    {
        progressblog = ProgressBlog.progressBlog;
        staytime = requirestaytime;
        sound = SoundManager.sound;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            progressblog.UpdateBoard("Lab");
            Player = other.gameObject;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<PlayerBehaviorControll>().losePatient();
                Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(waitpos.transform.position, waitpos.transform.rotation);
                stay = true;
                sound.LoadingSound.Play();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            stay = false;
            progressblog.Reset();
            other.GetComponent<PatientBehavior>().closedoneicon();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<PlayerBehaviorControll>().closeEIcon();
            progressblog.UpdateBoard("");
            done.SetActive(false);
        }
    }
    void doneLab()
    {
        done.SetActive(true);
        sound.LoadingSound.Stop();
        sound.QuestDone.Play();
        Patient.GetComponent<PatientsQuestData>().lableft = 0;
    }
    private void Update()
    {
        if (stay)
        {
            staytime -= Time.deltaTime;
            if (staytime <= 0)
            {
                doneLab();
                Reset();
            }
            fillImage.fillAmount = staytime / requirestaytime;
        }
    }
    private void Reset()
    {
        stay = false;
        staytime = requirestaytime;
        fillImage.fillAmount = staytime / requirestaytime;
    }
}
