using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScript : MonoBehaviour
{
    [SerializeField]
    GameObject ProfilePanel;
    bool opened,dbopened;

    SoundManager sound;
 
    private void Awake()
    {
        opened = false;
        
    }
    private void Start()
    {
        sound = SoundManager.sound;
    }

    public void onclickProfilPanel()
    {
        sound.PLayInteract();
        if (!opened)
        {
            ProfilePanel.SetActive(true);
            opened = true;
        }
        else
        {
            ProfilePanel.SetActive(false);
            opened = false;
        }
        
    }
    public void onclickDBBtn()
    {
        sound.PLayInteract();
        if (!dbopened)
        {
            ProfilePanel.SetActive(true);
            dbopened = true;
        }
        else
        {
            ProfilePanel.SetActive(false);
            dbopened = false;
        }
    }
}
