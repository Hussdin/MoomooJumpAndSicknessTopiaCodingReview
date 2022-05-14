using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DayManagement : MonoBehaviour
{
    CurrentGameDatatoconfig Data;
    public static DayManagement daymanage;

    [SerializeField]
    Image timer,clockhand;
    [SerializeField]
    GameObject dayEndPanel;
    [SerializeField]
    TMP_Text daytxt, coinTxt,nameTxt;

    public float Day, TimerPerday;
    float MaxTime, Current;
    float radius, MaxR;
    const float secperday = 600;
    float day;
    public float daycount;
    public int todayTreat;
    public bool dayend;

    private void Awake()
    {
        SaveSystem.LoadSave(PlayerPrefs.GetString("CurrentGame"));
        daymanage = this;
        dayend = false;
        todayTreat = 0;
        nameTxt.text = PlayerPrefs.GetString("CurrentGame");
    }
    private void Start()
    {
        Data = CurrentGameDatatoconfig.savegame;

        Day = Data.day;
        daytxt.text = Day.ToString();
        Addcoin(0);

    }
    private void Update()
    {
        TimerCountdown();
    }
    public void Addcoin(float amount)
    {
        Data.money += (int)amount;
        coinTxt.text = Data.money.ToString();
    }
    void TimerCountdown()
    {
        day += Time.deltaTime / secperday;
        daycount += 1 * Time.deltaTime;
        float dayNormalize = day % 1f;
        float rotationperday = 360;
        clockhand.transform.eulerAngles = new Vector3(0, 0, -dayNormalize * rotationperday);

        if (daycount >= secperday) 
        {
            if (Data.day != 0)
            {
                
                dayend = true;
            }
            else
            {
                //showEndDayPanel();
                dayend = true;
            }
        }
    }
    public void UpdtaeNextDay()
    {
        Day++;
        PlayerPrefs.SetFloat("Day", Day);
        SceneManager.LoadScene(0);
    }
    public void showEndDayPanel()
    {
        dayEndPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void EndofTheDay()
    {
        string savekey = PlayerPrefs.GetString("CurrentGame", "Empthy");
        Data.day += 1;
        Data.money += 100;
        Data.savedata(savekey,"save");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
    public void CalculateMoney(float emotionscore)
    {
        float Patientcost;
        if (emotionscore <=0)
        {
            Patientcost = 5;
        }
        else
        {
            Patientcost = Mathf.Round(emotionscore) * 2;
        }

        todayTreat += 1;
        Addcoin(Patientcost);
    }
}
