using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientBehavior : MonoBehaviour
{
    DayManagement dayManagement;
   SoundManager sound;
   public static PatientBehavior patientBehavior;
   QuestLogGuide questblock;
   AnimationController animcontroller;
   [SerializeField]
   GameObject doneicon,SpacIcon,Exitpos;
   Vector3 DefaultDesirepos;
   Vector3 DesirePos;
   Quaternion DesireRos;
   public bool stop;
   public new string name;
   int myque;
   public NavMeshAgent agent;
   Animator anim;
   public bool evertakecare;

    private void Awake()
   {
      DefaultDesirepos = this.transform.position;
      DesirePos = DefaultDesirepos;
      patientBehavior = this;
      name = this.gameObject.name;
      stop = true;
      agent = this.gameObject.GetComponent<NavMeshAgent>();
      anim = this.gameObject.GetComponent<Animator>();
    }
   
    private void Start()
    {
        EventManager.gameevent.OnenteringPatient += onenterPatient;
        EventManager.gameevent.OnexitingPatient += onexitingPatients;
        EventManager.gameevent.OnAnnounceQue += onTakeQue;

        sound = SoundManager.sound;
        animcontroller = AnimationController.animcontroll;
        questblock = QuestLogGuide.QuestBlockController;
        myque = this.GetComponent<Profile>().Que;
        dayManagement = DayManagement.daymanage;
        
    }
    private void Update()
    {
       animationcheck();
       checkdayend();
    }
    void animationcheck()
    {
        if (agent.enabled == true)
        {
            if (agent.remainingDistance != 0)
            {
                anim.SetBool("Walk", true);
            }
            else if (agent.remainingDistance == 0)
            {
                anim.SetBool("Walk", false);
            }
        } 
    }
    public void PatientFollow()
    {
        agent.SetDestination(DesirePos);
    }
    public void telltostop()
    {
        anim.SetBool("Walk", false);
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        agent.isStopped = true;
        agent.ResetPath();
        agent.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doneicon.SetActive(false);
        }
    }
    public void ChangePatientDesirePosition(Vector3 pos,Quaternion ros)
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        agent.enabled = true;
        DesirePos = pos;
        DesireRos = ros;
        PatientFollow();
    }
    public void showdoneicon()
    {
        doneicon.SetActive(true);
        sound.PLayQuestdone();
    }
    public void closedoneicon()
    {
        doneicon.SetActive(false);
    }
    void onenterPatient(string name)
    {
        if(name == this.name)
        {
           SpacIcon.SetActive(true);
        }
    }
    public void onexitingPatients(string name)
    {
        if (name == this.name)
        {
            SpacIcon.SetActive(false);
        }
    }

    private void OnDisable()
    {
        EventManager.gameevent.OnenteringPatient -= onenterPatient;
        EventManager.gameevent.OnexitingPatient -= onexitingPatients;
        EventManager.gameevent.OnAnnounceQue -= onTakeQue;
    }

    public void onTakeQue(int que)
    {
        GameObject pos = GameObject.FindGameObjectWithTag("QuePos");
        if (myque == que)
        {
            ChangePatientDesirePosition(pos.transform.position, pos.transform.rotation);
            GameObject receptable = GameObject.FindGameObjectWithTag("ReceptionTable");
            receptable.GetComponent<ReceptionTable>().que += 1;
        }
    }
    [SerializeField]
    GameObject questblog,ExitPos;
    public void onDoneTreat()
    {
        questblog.SetActive(false);
        ChangePatientDesirePosition(ExitPos.transform.position, ExitPos.transform.rotation);
    }

    void checkdayend()
    {
        if (!evertakecare)
        {
            if (dayManagement.dayend)
            {
                ChangePatientDesirePosition(Exitpos.transform.position, Exitpos.transform.rotation);
            }
        }
    }
}
