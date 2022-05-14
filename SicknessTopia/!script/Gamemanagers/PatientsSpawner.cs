using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientsSpawner : MonoBehaviour
{
    public static PatientsSpawner spawner;
    QueSystem QueSystem;
    CurrentGameDatatoconfig data;
    int Day;
    int que;
    [SerializeField]
    GameObject Patients1, Patients2, Patients3, Patients4, Patients5,Patients6;
    [SerializeField]
    GameObject SPatient1, SPatient2, SPatient3, SPatient4,specialPatientSpawnpoint,patientspawnpoint;
    private void Awake()
    {
        que = 0;
        spawner = this;
    }
    void Start()
    {
        QueSystem = QueSystem.Qsystem;
        data = CurrentGameDatatoconfig.savegame;
        Day = data.day;

       if(data.day == 0)
       {
            InvokeRepeating("spawnfirstdaycondition", 1, 5);
       }
       else
       {
            Spawner();
            Spawner();
            Spawner();
            Spawner();
            Spawner();
            Spawner();
            Spawner();
            Spawner();

        }
    }
    public void Spawner()
    {
        que += 1;
        GameObject dequeObject = QueSystem.DQ();
        int chance = Random.Range(1, 7);
        switch (chance)
        {
            case 1 :
                GameObject Patient1 = Instantiate(Patients1, patientspawnpoint.transform.position, patientspawnpoint.transform.rotation);
                setPatientsPersonalize(Patient1, chance,que);
                Patient1.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position, dequeObject.transform.rotation);
                break;
            case 2:
                GameObject Patient2 = Instantiate(Patients2, patientspawnpoint.transform.position, patientspawnpoint.transform.rotation);
                setPatientsPersonalize(Patient2, chance, que);
                Patient2.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position, dequeObject.transform.rotation);
                break;
            case 3:
                GameObject Patient3 = Instantiate(Patients3, patientspawnpoint.transform.position, patientspawnpoint.transform.rotation);
                setPatientsPersonalize(Patient3, chance, que);
                Patient3.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position, dequeObject.transform.rotation);
                break;
            case 4:
                GameObject Patient4 = Instantiate(Patients4, patientspawnpoint.transform.position, patientspawnpoint.transform.rotation);
                setPatientsPersonalize(Patient4, chance, que);
                Patient4.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position, dequeObject.transform.rotation);
                break;
            case 5:
                GameObject Patient5 = Instantiate(Patients5, patientspawnpoint.transform.position, patientspawnpoint.transform.rotation);
                setPatientsPersonalize(Patient5, chance, que);
                Patient5.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position, dequeObject.transform.rotation);
                break;
            case 6:
                GameObject Patient6 = Instantiate(Patients6, patientspawnpoint.transform.position, patientspawnpoint.transform.rotation);
                setPatientsPersonalize(Patient6, chance, que);
                Patient6.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position, dequeObject.transform.rotation);
                break;
        }
    }
    public void SpawnSpecialPatient()
    {
        GameObject dequeObject = QueSystem.DQS();
        int chance = Random.Range(7,11);
        switch (chance)
        {
            case 7:
                GameObject Patient1 = Instantiate(SPatient1, specialPatientSpawnpoint.transform.position, specialPatientSpawnpoint.transform.rotation);
                Patient1.transform.position = specialPatientSpawnpoint.transform.position;
                Patient1.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position,dequeObject.transform.rotation);
                break;
            case 8:
                GameObject Patient2 = Instantiate(SPatient2, specialPatientSpawnpoint.transform.position, specialPatientSpawnpoint.transform.rotation);
                Patient2.transform.position = specialPatientSpawnpoint.transform.position;
                Patient2.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position, dequeObject.transform.rotation);
                break;
            case 9:
                GameObject Patient3 = Instantiate(SPatient3, specialPatientSpawnpoint.transform.position, specialPatientSpawnpoint.transform.rotation);
                Patient3.transform.position = specialPatientSpawnpoint.transform.position;
                Patient3.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position, dequeObject.transform.rotation);
                break;
            case 10:
                GameObject Patient4 = Instantiate(SPatient4, specialPatientSpawnpoint.transform.position, specialPatientSpawnpoint.transform.rotation);
                Patient4.transform.position = specialPatientSpawnpoint.transform.position;
                Patient4.GetComponent<PatientBehavior>().ChangePatientDesirePosition(dequeObject.transform.position, dequeObject.transform.rotation);
                break;
        }
    }
    void setPatientsPersonalize(GameObject Patient,int PersonalID,int Que)
    {
        Patient.GetComponent<Profile>().PatientsPersonalize = PersonalID;
        Patient.GetComponent<Profile>().Que = Que;
    }

    int count = 5;
    void spawnfirstdaycondition()
    {
        if(count > 0)
        {
            Spawner();
            count--;
        }
    }
}
