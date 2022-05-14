using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiscussionTable : MonoBehaviour
{
    public static DiscussionTable discuss;
    SoundManager sound;

    MiniGameManager miniGameManager;
    QuestLogGuide quest;
    PredictionSystem system;
    [SerializeField]
    GameObject PredictionPanel,DiscussionPanel,DialogBlock,PatientPosition,PlayerPosition,PatientExitPos,PlayerExitPos,askmore;
    [SerializeField]
    TMP_Text Symtomtxtbox,DocName,PatientName;
    [SerializeField]
    GameObject RoomCam, BodyCam,EbuttonIcon,minigameblog;
    [SerializeField]
    Button SearchbodyBTN;
    [SerializeField]
    Image Doc, Patient;
    [SerializeField]
    GameObject body, ask, predict;
    [SerializeField]
    Sprite done, defaultbtn;

    public GameObject PatientObject,Player;
    bool patient, player;

    private void Start()
    {
        system = PredictionSystem.predicsys;
        sound = SoundManager.sound;
        miniGameManager = MiniGameManager.minigamemanager;
        quest = QuestLogGuide.QuestBlockController;
        DiseaseDetection = 1;
        DiseaseTxt();
    }
    private void Update()
    {
        if (DiscussionPanel.activeInHierarchy)
        {
            updateboard();
        } 
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            PatientObject = other.gameObject;
            PatientName.text = PatientObject.name;
            Patient.sprite = other.GetComponent<Profile>().MyPicture;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            RoomCam.SetActive(true);
            Player = other.gameObject;
            if (Input.GetKey(KeyCode.E))
            {
                EnterPredictionPhase(PatientObject,Player);
            }
        }
        if(patient && player)
        {
            DiscussionPanel.SetActive(true);
            patient = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RoomCam.gameObject.SetActive(false);
        }
    }

    void DialogSystem(string buttontype)
    {
        system = PredictionSystem.predicsys;
        string Dialog;
        switch (buttontype)
        {
            case "AskSymtom":
                Dialog = system.GetSymtomp("","Symptom");
                Symtomtxtbox.text = Dialog;
                if(Dialog != "ไม่มีแล้ว")
                {
                    PatientObject.GetComponent<Profile>().recieveSymptom(Dialog);
                    sound.playtalksound();
                }
                break;
            case "AskTime":
                Dialog = system.GetSymtomp("","Time");
                Symtomtxtbox.text = Dialog;
                break;
        }
        PatientObject.GetComponent<PatientsQuestData>().asksymtomps -= 1;
    }
    void fadeobj(string who)
    {
        var tempcolor = Doc.color;
        tempcolor.a = 0.3f;
        var defaultcolor = Color.white;
        defaultcolor.a = 1;

        if (who == "Doc")
        {
            Doc.color = tempcolor;
            DocName.color = tempcolor;

            Patient.color = defaultcolor;
            PatientName.color = defaultcolor;
        }
        else
        {
            Patient.color = tempcolor;
            PatientName.color = tempcolor;

            Doc.color = defaultcolor;
            DocName.color = defaultcolor;
        }
    }
    public void askSymptom()
    {
        if (!DialogBlock.activeInHierarchy)
        {
            DialogBlock.SetActive(true);
            DialogSystem("AskSymtom");
        }
        else
        {
            DialogSystem("AskSymtom");
        }
    }

    public void askTime()
    {
        DialogSystem("AskTime");
    }

    public void BodySearch()
    {
        DialogBlock.SetActive(false);
        BodyCam.gameObject.SetActive(true);
        RoomCam.gameObject.SetActive(false);

        DiscussionPanel.SetActive(false);
        minigameblog.SetActive(true);
    }
    [SerializeField]
    TMP_Text DiseaesText;
    int DiseaseDetection;
    public void SelectDisease()
    {
        sound.QuestDone.Play();
        Profile patient = PatientObject.GetComponent<Profile>();
        switch (DiseaseDetection)
        {
            case 1:
                patient.PredictionDisease = "ไข้หวัดธรรมดา";
                break;
            case 2:
                patient.PredictionDisease = "ไข้หวัดคออักเสบ(เชื้อไวรัส)";
                break;
            case 3:
                patient.PredictionDisease = "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)";
                break;
            case 4:
                patient.PredictionDisease = "ไข้หวัดปอดอักเสบ";
                break;
            case 5:
                patient.PredictionDisease = "ภูมิแพ้";
                break;
        }
        PatientObject.GetComponent<PatientsQuestData>().predict = 0;
        ExitPredictionPhase(PatientObject,Player);

    }
    public void ChooseDiseaseL()
    {
        DiseaseDetection -= 1;
        DiseaseTxt();
    }
    public void ChooseDiseaseR()
    {
        DiseaseDetection += 1;
        DiseaseTxt();
    }
    void DiseaseTxt()
    {
        if(DiseaseDetection > 5)
        {
            DiseaseDetection = 1;
        }
        else if(DiseaseDetection < 1)
        {
            DiseaseDetection = 5;
        }

        switch (DiseaseDetection)
        {
            case 1 :
                DiseaesText.text = "ไข้หวัดธรรมดา";
                break;
            case 2:
                DiseaesText.text = "ไข้หวัดคออักเสบ(เชื้อไวรัส)";
                break;
            case 3:
                DiseaesText.text = "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)";
                break;
            case 4:
                DiseaesText.text = "ไข้หวัดปอดอักเสบ";
                break;
            case 5:
                DiseaesText.text = "ภูมิแพ้";
                break;
        }
    }
    public void onclickPredictionPanel()
    {
        if (PredictionPanel.activeInHierarchy)
        {
            PredictionPanel.SetActive(false);
        }
        else
        {
            PredictionPanel.SetActive(true);
        }
        
    }

    void EnterPredictionPhase(GameObject Patient,GameObject Player)
    {
        if (Patient == null)
        {
            return;
        }
        else
        {
            checkSerchingbodyForpatient();
            Player.GetComponent<PlayerBehaviorControll>().losePatient();

            commandtoTable(Patient);

            Player.transform.position = PlayerPosition.transform.position;
            Player.transform.rotation = PlayerPosition.transform.rotation;

            DiscussionPanel.SetActive(true);
            RoomCam.gameObject.SetActive(true);

            //freezPlayer
            Player.GetComponent<Playercontroller>().enabled = false;
        }
        

    }

    void ExitPredictionPhase(GameObject Patient, GameObject Player)
    {
        Player.transform.position = PlayerExitPos.transform.position;
        Player.transform.rotation = PlayerExitPos.transform.rotation;
        commanToExitPoint(Patient);

        PredictionPanel.SetActive(false);
        DialogBlock.SetActive(false);
        DiscussionPanel.SetActive(false);
        RoomCam.gameObject.SetActive(false);

        //freezPlayer
        Player.GetComponent<Playercontroller>().enabled = true;
    }

    void commandtoTable(GameObject Patient)
    {
        Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(PatientPosition.transform.position,PatientPosition.transform.rotation);
        StartCoroutine(checngePatientRotation(Patient, PatientPosition.transform.rotation));
    }
    IEnumerator checngePatientRotation(GameObject Patient,Quaternion desireros)
    {
        yield return new WaitForSeconds(1);
        Patient.transform.rotation = desireros;
    }
    void commanToExitPoint(GameObject Patient)
    {
        Patient.GetComponent<PatientBehavior>().ChangePatientDesirePosition(PatientExitPos.transform.position, PatientExitPos.transform.rotation);
    }
    public void checkSerchingbodyForpatient()
    {
        if(PatientObject.GetComponent<PatientsQuestData>().SearchingBodyLeft <= 0)
        {
            SearchbodyBTN.interactable = false;
        }
        else
        {
            SearchbodyBTN.interactable = true;
        }
    }

   void updateboard()
   {
        checkbodybtn();
        checkaskbtn();
        checkpredictbtn();
   }
    void checkbodybtn()
    {
        if (PatientObject.GetComponent<PatientsQuestData>().SearchingBodyLeft <= 0)
        {
            body.GetComponent<Image>().sprite = done;
            body.GetComponent<Button>().interactable = false;
        }
        else
        {
            body.GetComponent<Image>().sprite = defaultbtn;
            body.GetComponent<Button>().interactable = true;
        }
    }
    void checkaskbtn()
    {
        if (PatientObject.GetComponent<PatientsQuestData>().asksymtomps <= 0)
        {
            ask.GetComponent<Image>().sprite = done;
            ask.GetComponent<Button>().interactable = false;
            askmore.GetComponent<Button>().interactable = false;
        }
        else
        {
            ask.GetComponent<Image>().sprite = defaultbtn;
            ask.GetComponent<Button>().interactable = true;
            askmore.GetComponent<Button>().interactable = true;
        }
    }
    void checkpredictbtn()
    {
        if (PatientObject.GetComponent<PatientsQuestData>().predict <= 0)
        {
            predict.GetComponent<Image>().sprite = done;
            predict.GetComponent<Button>().interactable = false;
        }
        else
        {
            predict.GetComponent<Image>().sprite = defaultbtn;
            predict.GetComponent<Button>().interactable = true;
        }
    }
}
