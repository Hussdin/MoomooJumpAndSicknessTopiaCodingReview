using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    SoundManager soundManager;
    public GameObject JB, BB, SB;
    public Text JBT, BBT, SBT;

    StatusScript status;

    private void Awake()
    {
        status = StatusScript.status; 
    }
  
    private void Update()
    {
        status = StatusScript.status;
        if (status.coin <= status.JumpforcePrice)
        {
            JB.GetComponent<Button>().interactable = false;
            JBT.color = Color.red;
        }
        if (status.coin <= status.BoostforcePrice)
        {
            BB.GetComponent<Button>().interactable = false;
            BBT.color = Color.red;
        }
        if (status.coin <= status.STRPrice)
        {
            SB.GetComponent<Button>().interactable = false;
            SBT.color = Color.red;
        }
        else
        {
            JB.GetComponent<Button>().interactable = true;
            BB.GetComponent<Button>().interactable = true;
            SB.GetComponent<Button>().interactable = true;
        }
    }

    public void onclickJFupgrade()
    {
        soundManager = SoundManager.soundManager;
        soundManager.playbuttonsound();
        if (status.coin >= status.JumpforcePrice)
        {
            if (status.JumpforceLV < 20)
            {
                soundManager.playCoinsound();
                status.OnUpgradeJumpforce();
            }
        }
    }

    public void onclickBFupgrade()
    {
        soundManager = SoundManager.soundManager;
        soundManager.playbuttonsound();
        if (status.coin >= status.BoostforcePrice)
        {
            if (status.BoostforceLV < 20)
            {
                soundManager.playCoinsound();
                status.OnUpgradeBoostforce();
            } 
        }
    }

    public void onclickSTRupgrade()
    {
        soundManager = SoundManager.soundManager;
        soundManager.playbuttonsound();
        if (status.coin >= status.STRPrice)
        {
            if (status.STRLV < 10)
            {
                soundManager.playCoinsound();
                status.OnUpgradeSTR();
            }
        }
    }
}
