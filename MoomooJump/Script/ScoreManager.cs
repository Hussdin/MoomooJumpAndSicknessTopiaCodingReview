using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text Scoretxt;
    float Currentscore, highscore,Currentcoin,oldHS;
    Rigidbody2D rb;
    [SerializeField]
    ParticleSystem PartyFlare;
    [SerializeField]
    AudioSource PartyPopper;
    bool alreadyplayanim;

    private void Awake()
    {
        alreadyplayanim = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Currentscore = 0f;
    }

    void Update()
    {
        if(rb.velocity.y >0 && transform.position.y > Currentscore)
        {
            Currentscore = transform.position.y;
        }

        Scoretxt.text = "SCORE : " + Mathf.Round(Currentscore * 10).ToString();
        PlayerPrefs.SetFloat("CurrentScore", Mathf.Round(Currentscore * 10));

        Currentcoin = Mathf.Round(PlayerPrefs.GetFloat("CurrentScore") / 30);
        PlayerPrefs.SetFloat("CurrentCoin", Currentcoin);

        SaveHighScore();

    }

    void SaveHighScore()
    {
        highscore = PlayerPrefs.GetFloat("HighScore");
        if (highscore == 0)
        {
            alreadyplayanim = true;
        }
        if (PlayerPrefs.GetFloat("CurrentScore") > highscore)
        {
            if(alreadyplayanim == false)
            {
                alreadyplayanim = true;
                PartyPopper.Play();
                PartyFlare.Play();
            }
            highscore = PlayerPrefs.GetFloat("CurrentScore");
            PlayerPrefs.SetFloat("HighScore", highscore);
           
        } 
    }

}
