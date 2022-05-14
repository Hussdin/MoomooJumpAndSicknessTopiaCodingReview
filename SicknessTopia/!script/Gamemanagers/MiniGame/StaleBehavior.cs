using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StaleBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    StaleMiniGame staleMiniGame;
    SoundManager sound;
    EmergencyBed bed;
    bool pointerDown;
    float PDTimer;
    public float requredHoldTime;
    public UnityEvent onLongClick;
    [SerializeField]
    Image me,fillImage,Water;
    [SerializeField]
    Sprite done,defaults;
    [SerializeField]
    GameObject bandage,IdleCircle;
    public string stage,currenttool;

    int count;
    private void Awake()
    {
        PDTimer = requredHoldTime;
        count = 3;
    }
    private void Start()
    {
        bed = EmergencyBed.emergencyBed;
        sound = SoundManager.sound;
        staleMiniGame = StaleMiniGame.staleMiniGame;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = transform;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }
 
    private void Update()
    {
        currenttool = PlayerPrefs.GetString("currenttool");
        if (pointerDown)
        {
            if (currenttool=="Ice")
            {
                PDTimer -= Time.deltaTime;
                if (PDTimer <= 0)
                {
                    if (onLongClick != null)
                    {
                        onLongClick.Invoke();
                        Reset();
                    }
                }
                fillImage.fillAmount = PDTimer / requredHoldTime;
            }
            if (stage == "Wet")
            {
                if (currenttool == "Towel")
                {
                    Color setalpha = new Color32(0, 0, 0, 90);
                    Water.color -= setalpha;
                    if (Water.GetComponent<Image>().color.a > 0)
                    {
                        return;
                    }
                    else
                    {
                        dry();
                    }
                }     
            }
            if (stage == "Ready")
            {
                requredHoldTime = 6;
                if (currenttool == "Bandage")
                {
                    sound.bandagr.Play();
                    PDTimer -= Time.deltaTime;
                    if (PDTimer <= 0)
                    {
                         ondoneBandage();
                         Reset();
                    }
                    IdleCircle.GetComponent<Image>().fillAmount = PDTimer / requredHoldTime;
                }
            }
            
        }
        else
        {
            sound.bandagr.Stop();
        }
    }
    private void Reset()
    {
        pointerDown = false;
        PDTimer = requredHoldTime;
        fillImage.fillAmount = PDTimer / requredHoldTime;
    }
    public void onstaledone()
    {
        stage = "Wet";
        me.sprite = done;
        Water.gameObject.SetActive(true);
        Invoke("setfalse", 1);
    }
    public void dry()
    {
        stage = "Ready";
        Debug.Log("before" + staleMiniGame.treatcount);
        staleMiniGame.treatcount -= 1;
        Debug.Log("After" + staleMiniGame.treatcount);
        if (staleMiniGame.treatcount <= 0)
        {
            IdleCircle.SetActive(true);
            staleMiniGame.treatcount = 3;
        }
    }
    void setfalse()
    {
        me.gameObject.SetActive(false);
    }
    void ondoneBandage()
    {
        bandage.gameObject.SetActive(true);
        IdleCircle.SetActive(false);
        Invoke("ondone",2);
    }
    void ondone()
    {
        bed.onDoneTreat();
    }
    void Resetwound()
    {
        bandage.gameObject.SetActive(false);
        stage = "";
        me.sprite = defaults;
        me.gameObject.SetActive(true);
        Water.color += new Color32(225, 225, 225, 225);
        Water.gameObject.SetActive(false);
        IdleCircle.SetActive(false);
    }
    private void OnDisable()
    {
        Resetwound();
    }
}
