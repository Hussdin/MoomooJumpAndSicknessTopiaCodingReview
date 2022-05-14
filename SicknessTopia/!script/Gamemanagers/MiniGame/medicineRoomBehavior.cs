using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medicineRoomBehavior : MonoBehaviour
{
    public static medicineRoomBehavior MedicineRoomBehavior;
    DayManagement daymanage;
    History history;

    [SerializeField]
    GameObject MedicinePanel,ExitPosition;
    GameObject player, patient;
    bool withpatient;
    private void Awake()
    {
        MedicineRoomBehavior = this;
        history = History.history;
    }
    private void Start()
    {
        daymanage = DayManagement.daymanage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            player.GetComponent<PlayerBehaviorControll>().showEIcon();
        }
        if (other.gameObject.CompareTag("Patient"))
        {
            patient = other.gameObject;
            withpatient = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerBehaviorControll>().closeEIcon();
        }
        if (other.gameObject.CompareTag("Patient"))
        {
            withpatient = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && withpatient)
            {
                MedicinePanel.SetActive(true);
            }
        }
    }

    public void CheckoutPatient(List<string>Med)
    {
        patient.GetComponent<Profile>().RecievedMedicine = Med;
        player.GetComponent<PlayerBehaviorControll>().losePatient();
        player.GetComponent<PlayerBehaviorControll>().Patients = null;

        patient.GetComponent<PatientsQuestData>().Takemedicineleft = 0;
        patient.GetComponent<PatientsEmotional>().removemethod("จ่ายยาตามอาการ");
        patient.GetComponent<PatientsEmotional>().checkMethod(patient);

        daymanage.CalculateMoney(patient.GetComponent<PatientsEmotional>().EmotionScore);

        patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(ExitPosition.transform.position, ExitPosition.transform.rotation);
        history = History.history;
        history.createhistorybox(patient);
    }
}
