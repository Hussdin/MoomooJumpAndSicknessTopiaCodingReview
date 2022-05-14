using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text Currentscore, Highscore, currentcoin, cointxt;
    
    public Text JumpforceLv, JumpForcePrice, BoostforeceLv, BoostforcePrice , STRLV,STRPrice;
    AdMobScript ads;
    SoundManager soundManager;
    [SerializeField]
    AudioSource coinsplash;

    int counttoshowads;

    StatusScript status;

    private void Awake()
    {
        status = StatusScript.status;
        coinsplash.pitch = Time.timeScale;
        coinsplash.Play();
        showinfo();
        counttoshowads = PlayerPrefs.GetInt("Count",0);
        counttoshowads ++;
        PlayerPrefs.SetInt("Count", counttoshowads);
        ads = AdMobScript.instance;
        showinterstitialads();
    }
    private void Start()
    {
        status.calculatecoin();
    }

    void Update()
    {
        cointxt.text = status.coin.ToString();

        Currentscore.text = PlayerPrefs.GetFloat("CurrentScore",0).ToString();
        Highscore.text = Mathf.Round( PlayerPrefs.GetFloat("HighScore",0)).ToString();

        currentcoin.text = PlayerPrefs.GetFloat("CurrentCoin",0).ToString();
        showinfo();
    }
    public void Playagain()
    {
        soundManager = SoundManager.soundManager;
        soundManager.playchangescenesound();
        SceneManager.LoadScene("MainScene");
        PlayerPrefs.SetFloat("CurrentCoin", 0);
        PlayerPrefs.SetFloat("CurrentScore", 0);
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
        if (count %3 ==0)
        {
            ads.showInterstitialAds();
            counttoshowads = 0;
            PlayerPrefs.SetInt("Count", counttoshowads);
        }
    }
}
