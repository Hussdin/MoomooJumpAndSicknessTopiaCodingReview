using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager gameevent;

    public  event Action PressAction;
    public  event Action FollowPlayer;

    public  event Action<string> OnenteringPatient;
    public event Action<string> OnexitingPatient;

    public event Action AnnounceQue;
    public event Action<int> OnAnnounceQue;


    private void Awake()
    {
        gameevent = this;
    }

    public void EnteringPatients(string name)
    {
        if(OnenteringPatient != null)
        {
            OnenteringPatient(name);
        }
    }
    public void ExitingPatient(string name)
    {
        if (OnexitingPatient != null)
        {
            OnexitingPatient(name);
        }
    }

    public void announceQue(int que)
    {
        if(OnAnnounceQue != null)
        {
            OnAnnounceQue(que);
        }
    }

}
