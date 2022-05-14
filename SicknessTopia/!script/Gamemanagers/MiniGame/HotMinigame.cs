using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotMinigame : MonoBehaviour
{
    [SerializeField]
    GameObject cream, got, tape,Towel,iodin;
    public void OnclickTowel()
    {
        if(Towel.activeInHierarchy)
        {
            Towel.SetActive(false);
            PlayerPrefs.SetString("currenttool", "");
        }
        else
        {
            PlayerPrefs.SetString("currenttool", "Towel");
            cream.SetActive(false);
            got.SetActive(false);
            tape.SetActive(false);
            Towel.SetActive(true);
            iodin.SetActive(false);
        }
    }
    public void Cream()
    {
        if (cream.activeInHierarchy)
        {
            cream.SetActive(false);
            PlayerPrefs.SetString("currenttool", "");
        }
        else
        {
            PlayerPrefs.SetString("currenttool", "Cream");
            cream.SetActive(true);
            got.SetActive(false);
            tape.SetActive(false);
            Towel.SetActive(false);
            iodin.SetActive(false);
        }
       
    }
    public void Got()
    {
        if (got.activeInHierarchy)
        {
            got.SetActive(false);
            PlayerPrefs.SetString("currenttool", "");
        }
        else
        {
            PlayerPrefs.SetString("currenttool", "Got");
            cream.SetActive(false);
            got.SetActive(true);
            tape.SetActive(false);
            Towel.SetActive(false);
            iodin.SetActive(false);
        }
    }
    public void iodinbottle()
    {
        if (iodin.activeInHierarchy)
        {
            iodin.SetActive(false);
            PlayerPrefs.SetString("currenttool", "");
        }
        else
        {
            PlayerPrefs.SetString("currenttool", "IodinBottle");
            cream.SetActive(false);
            got.SetActive(false);
            tape.SetActive(false);
            Towel.SetActive(false);
            iodin.SetActive(true);
        }
    }
    public void Tape()
    {
        if (tape.activeInHierarchy)
        {
            tape.SetActive(false);
            PlayerPrefs.SetString("currenttool", "");
        }
        else
        {
            PlayerPrefs.SetString("currenttool", "Tape");
            cream.SetActive(false);
            got.SetActive(false);
            tape.SetActive(true);
            Towel.SetActive(false);
            iodin.SetActive(false);
        }
    }

    public void Bin()
    {
        PlayerPrefs.SetString("currenttool", "");
        cream.SetActive(false);
        got.SetActive(false);
        tape.SetActive(false);
        Towel.SetActive(false);
        iodin.SetActive(false);
    }
    private void Update()
    {
        cream.transform.position = Input.mousePosition;
        got.transform.position = Input.mousePosition;
        tape.transform.position = Input.mousePosition;
        Towel.transform.position = Input.mousePosition;
        iodin.transform.position = Input.mousePosition;
    }
}
