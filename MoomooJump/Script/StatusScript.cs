using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusScript : MonoBehaviour
{
    public static StatusScript status;

    public float coin;
    public float Jumpforce, JumpforceLV , JumpforcePrice ;
    public float Boostforce, BoostforceLV, BoostforcePrice ;
    public float STR , STRLV, STRPrice;
    public float ItemSpawnRate;
    private void Awake()
    {
        status = this;
        coin = PlayerPrefs.GetFloat("coin",0);
    }

    private void Update()
    {
        Jumpforce = PlayerPrefs.GetFloat("Jumpforce",10);
        JumpforceLV = PlayerPrefs.GetFloat("JumpforceLV",1);
        JumpforcePrice = PlayerPrefs.GetFloat("JumpforcePrice",75);

        Boostforce = PlayerPrefs.GetFloat("Boostforce",20);
        BoostforceLV = PlayerPrefs.GetFloat("BoostforceLV",1);
        BoostforcePrice = PlayerPrefs.GetFloat("BoostforcePrice",150);
        ItemSpawnRate = PlayerPrefs.GetFloat("ItemSpawnRate", 200);

        STR = PlayerPrefs.GetFloat("STR",1);
        STRLV = PlayerPrefs.GetFloat("STRLV",1);
        STRPrice = PlayerPrefs.GetFloat("STRPrice",100);

        coin = PlayerPrefs.GetFloat("coin");
    }

    public void OnUpgradeJumpforce()
    {
        Jumpforce += 1.5f;
        JumpforceLV += 1;
        coin -= JumpforcePrice;
        JumpforcePrice += 75;

        PlayerPrefs.SetFloat("Jumpforce", Jumpforce);
        PlayerPrefs.SetFloat("JumpforceLV", JumpforceLV);
        PlayerPrefs.SetFloat("JumpforcePrice", JumpforcePrice);
        PlayerPrefs.SetFloat("coin", coin);
    }

    public void OnUpgradeBoostforce()
    {
        Boostforce += 6f;
        BoostforceLV += 1;
        coin -= BoostforcePrice;
        BoostforcePrice += 150;
        ItemSpawnRate += 110;

        PlayerPrefs.SetFloat("Boostforce", Boostforce);
        PlayerPrefs.SetFloat("BoostforceLV", BoostforceLV);
        PlayerPrefs.SetFloat("BoostforcePrice", BoostforcePrice);
        PlayerPrefs.SetFloat("coin", coin);
        PlayerPrefs.SetFloat("ItemSpawnRate", ItemSpawnRate);
    }

    public void OnUpgradeSTR()
    {
        STR += 1f;
        STRLV += 1;
        coin -= STRPrice;
        STRPrice += 250;

        PlayerPrefs.SetFloat("STR", STR);
        PlayerPrefs.SetFloat("STRLV", STRLV);
        PlayerPrefs.SetFloat("STRPrice", STRPrice);
        PlayerPrefs.SetFloat("coin", coin);
    }

    public void calculatecoin()
    {
        coin += PlayerPrefs.GetFloat("CurrentCoin");
        PlayerPrefs.DeleteKey("CurrentCoin");
        PlayerPrefs.SetFloat("coin", coin);
    }

}
