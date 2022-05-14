using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [SerializeField]
     GameObject Stethoscope,Thermometer,Flashlight;

    string currenttool;

    private void Awake()
    {
        currenttool = "";    
    }
    public void onclickStethoscope()
    {
        if (PlayerPrefs.GetString("currenttool") == "Stethoscope")
        {
            Stethoscope.SetActive(false);
            PlayerPrefs.SetString("currenttool", "");
        }
        else
        {
            currenttool = "Stethoscope";
            PlayerPrefs.SetString("currenttool", currenttool);
            Thermometer.SetActive(false);
            Stethoscope.SetActive(true);
            Flashlight.SetActive(false);
        }
    }
    public void onclickThermometer()
    {
        if (PlayerPrefs.GetString("currenttool") == "Thermometer")
        {
            Thermometer.SetActive(false);
            PlayerPrefs.SetString("currenttool", "");
        }
        else
        {
            currenttool = "Thermometer";
            PlayerPrefs.SetString("currenttool", currenttool);
            Stethoscope.SetActive(false);
            Thermometer.SetActive(true);
            Flashlight.SetActive(false);
        }
    }
    public void onclickFlashlight()
    {
        if (PlayerPrefs.GetString("currenttool") == "Flashlight")
        {
            Flashlight.SetActive(false);
            PlayerPrefs.SetString("currenttool", "");
        }
        else
        {
            currenttool = "Flashlight";
            PlayerPrefs.SetString("currenttool", currenttool);
            Stethoscope.SetActive(false);
            Thermometer.SetActive(false);
            Flashlight.SetActive(true);
        }
    }
}
