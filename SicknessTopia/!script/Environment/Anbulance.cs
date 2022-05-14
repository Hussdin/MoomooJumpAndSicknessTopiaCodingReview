using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anbulance : MonoBehaviour
{
    SoundManager sound;
    public static Anbulance ambulance;
    PatientsSpawner spawner;
    [SerializeField]
    GameObject Ambulance,Startpos, ExitPos,siren;
    public bool onduty,back;
    CurrentGameDatatoconfig data;
    int firstdayeventcount;
    bool alreadyonsiren;
    private void Awake()
    {
        ambulance = this;
    }
    private void Start()
    {
        spawner = PatientsSpawner.spawner;
        data = CurrentGameDatatoconfig.savegame;
        sound = SoundManager.sound;
        if(data.day == 0)
        {
            firstdayeventcount = 4;
        }
    }
    private void Update()
    {
        Work();
        if (back)
        {
            backtostartpos();
        }
    }

    void Work()
    {
        if (data.day == 0)
        {
            if (firstdayeventcount >= 0)
            {
                if (onduty)
                {
                    Ambulance.transform.position = Vector3.MoveTowards(Ambulance.transform.position, ExitPos.transform.position, 10 * Time.deltaTime);
                    if (Ambulance.transform.position == ExitPos.transform.position)
                    {
                        onduty = false;
                        Invoke("getback", 10);
                        Ambulance.gameObject.SetActive(false);
                    }
                }
            }

        }
    }
    void backtostartpos()
    {
        Ambulance.gameObject.SetActive(true);
        
        Invoke("offsiren", 5);
        Ambulance.transform.position = Vector3.MoveTowards(Ambulance.transform.position, Startpos.transform.position, 10* Time.deltaTime);
        if (!alreadyonsiren)
        {
            siren.SetActive(true);
            sound.siren.Play();
            alreadyonsiren = true;
        }
        if (Ambulance.transform.position == Startpos.transform.position)
        {
            back = false;
            spawn();
        }
    }
    void getback()
    {
        back = true;
    }
    void spawn()
    {
        spawner.SpawnSpecialPatient();
    }
    void offsiren()
    {
        siren.SetActive(false);
        sound.siren.Stop();
        alreadyonsiren = false;
    }
}
