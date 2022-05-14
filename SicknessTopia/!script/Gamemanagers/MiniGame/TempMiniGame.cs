using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMiniGame : MonoBehaviour
{
    MiniGameManager MiniGameManager;
    PredictionSystem Playeridentify;
    public static TempMiniGame tempMiniGame;
    public int counttoend;
    GameObject Patient;
    private void Awake()
    {
        tempMiniGame = this;
        
    }
    private void Start()
    {
        Playeridentify = PredictionSystem.predicsys;
        Patient = Playeridentify.Patient;
        counttoend = Patient.GetComponent<PatientsQuestData>().Temp;
    }
    private void OnEnable()
    {
        Playeridentify = PredictionSystem.predicsys;
        Patient = Playeridentify.Patient;
        counttoend = Patient.GetComponent<PatientsQuestData>().Temp;
    }
    public void minigameDone()
    {
        string Disease = Patient.GetComponent<Profile>().Disease;
        MiniGameManager = MiniGameManager.minigamemanager;
        getTemp(Disease);
        MiniGameManager.SetToDone("Temp", Disease);
        Patient.GetComponent<PatientsQuestData>().Temp = 0;
        Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft -= 1;
        if(Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft <= 0)
        {
            MiniGameManager.closeMinigamePanel();
        }
    }
    void getTemp(string disease)
    {
        float temp;
        if (disease == "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)")
        {
            temp = Random.Range(38.5f, 41);
            temp = Mathf.Round(temp * 10.0f) * 0.1f;
        }
        else
        {
            temp = Random.Range(37.5f,38.5f);
            temp = Mathf.Round(temp * 10.0f) * 0.1f;
        }
        Patient.GetComponent<Profile>().temp = temp;
    }
}
