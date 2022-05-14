using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotWoundBehavior : MonoBehaviour
{
    SoundManager sound;
    EmergencyBed bed;
    string stage;
    string currenttool;
    [SerializeField]
    GameObject Cream, got, t1, t2,dust,water,Iodinbottle;
    [SerializeField]
    Sprite normal, pour;
    int tcount;

    private void Start()
    {
        stage = "Beginning";
        bed = EmergencyBed.emergencyBed;
        sound = SoundManager.sound;
    }
    private void Update()
    {
        currenttool = PlayerPrefs.GetString("currenttool");
    }
    void resetiodin()
    {
        Iodinbottle.GetComponent<Image>().sprite = normal;
        sound.pouring.Stop();
        water.SetActive(true);
    }
    public void onclick()
    {
        switch (stage)
        {
            default:
                break;
            case "Beginning":
                if (currenttool == "IodinBottle")
                {
                    dust.SetActive(false);
                    Iodinbottle.GetComponent<Image>().sprite = pour;
                    sound.pouring.Play();
                    Invoke("resetiodin", 0.5f);
                    stage = "Wet";
                }
                break;
            case "Wet":
                if (currenttool == "Towel")
                {
                    sound.push.Play();
                    water.SetActive(false);
                    stage = "Clean";
                }
                break;
            case "Clean":
                if (currenttool == "Cream")
                {
                    sound.push.Play();
                    Cream.SetActive(true);
                    stage = "Ready";
                }
                break;
            case "Ready":
                if (currenttool == "Got")
                {
                    sound.push.Play();
                    got.SetActive(true);
                    stage = "Seal";
                }
                break;
            case "Seal":
                if (currenttool == "Tape")
                {
                    sound.tape.Play();
                    if (tcount < 1)
                    {
                        t1.SetActive(true);
                        tcount++;
                    }
                    else
                    {
                        t2.SetActive(true);
                        Invoke("ondone", 2);
                    }
                }
                break;
        }
    }

    private void Reset()
    {
        stage = "Beginning";
        t1.SetActive(false);
        t2.SetActive(false);
        got.SetActive(false);
        Cream.SetActive(false);
        water.SetActive(false);
        tcount = 0;
    }
    private void OnDisable()
    {
        Reset();
    }
    void ondone()
    {
        bed.onDoneTreat();
    }
}
