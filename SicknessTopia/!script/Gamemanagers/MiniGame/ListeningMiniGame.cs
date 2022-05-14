using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListeningMiniGame : MonoBehaviour
{
    MiniGameManager MiniGameManager;
    PredictionSystem Playeridentify;
    public static ListeningMiniGame listeningMiniGame;
    public int counttoend;
    GameObject Patient;
    private void Awake()
    {
        listeningMiniGame = this;
    }
    private void Start()
    {
        Playeridentify = PredictionSystem.predicsys;
        Patient = Playeridentify.Patient;
        counttoend = Patient.GetComponent<PatientsQuestData>().Listening;
    }
    private void OnEnable()
    {
        Playeridentify = PredictionSystem.predicsys;
        Patient = Playeridentify.Patient;
        counttoend = Patient.GetComponent<PatientsQuestData>().Listening;
    }
    public void minigameDone()
    {
        string Disease = Patient.GetComponent<Profile>().Disease;
        MiniGameManager = MiniGameManager.minigamemanager;
        MiniGameManager.SetToDone("Listening",Disease);
        Patient.GetComponent<PatientsQuestData>().Listening = 0;
        Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft -= 1;
        if (Patient.GetComponent<PatientsQuestData>().SearchingBodyLeft <= 0)
        {
            MiniGameManager.closeMinigamePanel();
        }
    }
}
