using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSetting : MonoBehaviour
{
    public GameObject player,joystick;
   
    private void Update()
    {
        if (PlayerPrefs.GetString("control","drag") == "tilt") 
        {
            joystick.gameObject.SetActive(false);
            player.GetComponent<JoystickControl>().enabled = false;
            player.GetComponent<TiltPlayerControl>().enabled = true;
        }
        if(PlayerPrefs.GetString("control", "drag") == "drag")
        {
            joystick.gameObject.SetActive(true);
            player.GetComponent<JoystickControl>().enabled = true;
            player.GetComponent<TiltPlayerControl>().enabled = false;
        }
    }
}
