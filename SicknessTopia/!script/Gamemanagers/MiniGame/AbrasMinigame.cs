using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbrasMinigame : MonoBehaviour
{
    public static AbrasMinigame abras; 
    [SerializeField]
    GameObject CursorTool,Bandage;
    [SerializeField]
    Sprite Empthy, Al, beta, cotton,cottonblood,iodin;
    bool oncotton;
    public Vector3 offset;
    private void Awake()
    {
        abras = this;
    }
    public void onclickCleaningTool()
    {
        Bandage.SetActive(false);
        CursorTool.GetComponent<Image>().sprite = Empthy;
        CursorTool.SetActive(true);
        PlayerPrefs.SetString("currenttool", "clean");
    }
    public void Cotton()
    {
        CursorTool.GetComponent<Image>().sprite = cotton;
        PlayerPrefs.SetString("currenttool","cotton");
        oncotton = true;
    }
    public void Beta()
    {
        if (oncotton)
        {
            CursorTool.GetComponent<Image>().sprite = beta;
            PlayerPrefs.SetString("currenttool", "beta");
        }
    }
    public void Alcohol()
    {
        if (oncotton)
        {
            CursorTool.GetComponent<Image>().sprite = Al;
            PlayerPrefs.SetString("currenttool", "al");
        }
    }
    public void Cottonblood()
    {
        if (oncotton)
        {
            CursorTool.GetComponent<Image>().sprite = cottonblood;
            PlayerPrefs.SetString("currenttool", "cottonblood");
        }
    }
    public void Iodin()
    {
        if (oncotton)
        {
            CursorTool.GetComponent<Image>().sprite = iodin;
            PlayerPrefs.SetString("currenttool", "iodin");
        }
    }
    public void Bin()
    {
        CursorTool.GetComponent<Image>().sprite = Empthy;
        oncotton = false;
        PlayerPrefs.SetString("currenttool", "clean");
    }
    public void Bandagebtn()
    {
        PlayerPrefs.SetString("currenttool", "Bandage");
        CursorTool.SetActive(false);
        Bandage.SetActive(true);
    }
    private void Update()
    {
        CursorTool.transform.position = Input.mousePosition + new Vector3(70,150,0);
        Bandage.transform.position = Input.mousePosition + offset;
    }
}
