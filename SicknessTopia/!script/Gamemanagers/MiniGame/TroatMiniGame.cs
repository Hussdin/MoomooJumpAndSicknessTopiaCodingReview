using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroatMiniGame : MonoBehaviour
{
    MiniGameManager MiniGameManager;
    PredictionSystem Playeridentify;
    public static TroatMiniGame TroatMiniGames;
    public int counttoend;
    GameObject Patient;
    private void Awake()
    {
        TroatMiniGames = this;
    }
    private void Start()
    {
        Playeridentify = PredictionSystem.predicsys;
        Patient = Playeridentify.Patient;
        counttoend = Patient.GetComponent<PatientsQuestData>().Troat;

    }
    private void OnEnable()
    {
        Playeridentify = PredictionSystem.predicsys;
        Patient = Playeridentify.Patient;
        counttoend = Patient.GetComponent<PatientsQuestData>().Troat;
    }
    public void minigameDone()
    {
        string Disease = Patient.GetComponent<Profile>().Disease;

        MiniGameManager = MiniGameManager.minigamemanager;
        MiniGameManager.SetToDone("Troat",Disease);
        Patient.GetComponent<PatientsQuestData>().Troat = 0;
        Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft -= 1;
        if (Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft <= 0)
        {
            MiniGameManager.closeMinigamePanel();
        }
    }
}
