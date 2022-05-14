using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public Text cointxt,HStxt;

    public Text JumpforceLv, JumpForcePrice, BoostforeceLv, BoostforcePrice, STRLV, STRPrice;
    SoundManager soundManager;
    StatusScript status;

    AdMobScript ads;
    int counttoshowads;

    private void Awake()
    {
        status = StatusScript.status;
    }
    private void Start()
    {
        status = StatusScript.status;
        status.calculatecoin();

        counttoshowads = PlayerPrefs.GetInt("Count", 0);
        counttoshowads++;
        PlayerPrefs.SetInt("Count", counttoshowads);
        ads = AdMobScript.instance;
        showinterstitialads();
    }

    void Update()
    {  
        showinfo();
        cointxt.text = status.coin.ToString();
        HStxt.text = "HighScore \n" + PlayerPrefs.GetFloat("HighScore", 0);
    }
    void showinfo()
    {
        status = StatusScript.status;
        JumpforceLv.text = "LV" + status.JumpforceLV.ToString(); ;
        JumpForcePrice.text = status.JumpforcePrice.ToString();

        BoostforeceLv.text = "LV" + status.BoostforceLV.ToString();
        BoostforcePrice.text = status.BoostforcePrice.ToString();

        STRLV.text = "LV" + status.STRLV.ToString();
        STRPrice.text = status.STRPrice.ToString();
    }

    void showinterstitialads()
    {
        int count = PlayerPrefs.GetInt("Count");
        if (count % 3 == 0)
        {
            ads.showInterstitialAds();
            counttoshowads = 0;
            PlayerPrefs.SetInt("Count", counttoshowads);
        }
    }
}
