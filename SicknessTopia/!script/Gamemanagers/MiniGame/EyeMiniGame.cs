using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMiniGame : MonoBehaviour
{
    MiniGameManager MiniGameManager;
    PredictionSystem Playeridentify;
    public static EyeMiniGame EyeMiniGames;
    public int counttoend;
    GameObject Patient;
    bool done;
    private void Awake()
    {
        EyeMiniGames = this;
        done = false;
    }
    private void Start()
    {
        Playeridentify = PredictionSystem.predicsys;
        Patient = Playeridentify.Patient;
        counttoend = Patient.GetComponent<PatientsQuestData>().Eye;
    }
    private void OnEnable()
    {
        Playeridentify = PredictionSystem.predicsys;
        Patient = Playeridentify.Patient;
        counttoend = Patient.GetComponent<PatientsQuestData>().Eye;
    }
    public void minigameDone()
    {
        string Disease = Patient.GetComponent<Profile>().Disease;
        MiniGameManager = MiniGameManager.minigamemanager;
        MiniGameManager.SetToDone("Eye", Disease);
        Patient.GetComponent<PatientsQuestData>().Eye = 0;
        Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft -= 1;
        if (Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft <= 0)
        {
            MiniGameManager.closeMinigamePanel();
        }
    }
}
