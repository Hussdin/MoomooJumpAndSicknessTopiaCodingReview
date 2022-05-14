using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoundBehavior : MonoBehaviour
{
    EmergencyBed bed;
    AbrasMinigame abras;
    string wound;
    string currenttool;
    public string stage;
    [SerializeField]
    Sprite nonbleed,defaults;
    [SerializeField]
    GameObject Blooddust,Betadin,Bandaged;

    bool Iced;
    private void Awake()
    {
        wound = this.gameObject.name;
        stage = "Bleeding";
    }
    private void Start()
    {
        abras = AbrasMinigame.abras;
        bed = EmergencyBed.emergencyBed;
    }
    private void Update()
    {
        currenttool = PlayerPrefs.GetString("currenttool");
    }
    public void onclick()
    {
        switch (stage)
        {
            default:
                break;
            case "Bleeding":
                if(currenttool == "cotton")
                {
                    this.gameObject.GetComponent<Image>().sprite = nonbleed;
                    abras.Cottonblood();
                    stage = "StopBleeding";
                }
                break;
            case "StopBleeding":
                if(currenttool == "al")
                {
                    Color alphavalue = new Color32(0, 0, 0, 90);
                    if (Blooddust.gameObject.GetComponent<Image>().color.a <= 0)
                    {
                        stage = "Cleaned";
                    }
                    else
                    {
                        Blooddust.gameObject.GetComponent<Image>().color -= alphavalue;
                        if (Blooddust.gameObject.GetComponent<Image>().color.a <= 0)
                        {
                            stage = "Cleaned";
                        }
                    }
                }
                break;
            case "Cleaned":
                if (currenttool == "beta")
                {
                    Color alphavalue = new Color32(0, 0, 0, 90);
                    if (Betadin.GetComponent<Image>().color.a >= 1f)
                    {
                        stage = "treated";
                    }
                    else
                    {
                        Betadin.GetComponent<Image>().color += alphavalue;
                    }
                }
                break;
            case "treated":
                if (currenttool == "Bandage")
                {
                    Bandaged.SetActive(true);
                    Invoke("ondone", 2);
                }
                break;
        }
    }
    private void OnDisable()
    {
        Reset();
    }
    private void Reset()
    {
        stage = "Bleeding";
        Bandaged.SetActive(false);
        Color Resetalpha = new Color32(0, 0, 0, 200);
        Blooddust.gameObject.GetComponent<Image>().color += Resetalpha;
        Color ResetalphaBetadin = new Color32(0, 0, 0, 255);
        Betadin.GetComponent<Image>().color -= ResetalphaBetadin;
        this.gameObject.GetComponent<Image>().sprite = defaults;
    }
    void ondone()
    {
        bed.onDoneTreat();
    }
}
