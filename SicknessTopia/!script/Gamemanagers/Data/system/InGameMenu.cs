using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    CurrentGameDatatoconfig data;

    [SerializeField]
    GameObject PausePanel;
    [SerializeField]
    TMP_Text Day, Money,Name;
    [SerializeField]
    GameObject Music;
    [SerializeField]
    Slider slider;

    private void Start()
    {
        data = CurrentGameDatatoconfig.savegame;
    }
    private void Update()
    {
        checkESCpress();
        checksoundvolum();
    }
    void checkESCpress()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausePanel.activeInHierarchy)
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                PausePanel.SetActive(true);
                Name.text = PlayerPrefs.GetString("CurrentGame");
                Day.text = data.day.ToString();
                Money.text = data.money.ToString();

                Time.timeScale = 0;
            }
        }
    }
    void checksoundvolum()
    {
        AudioSource music = Music.GetComponent<AudioSource>();
        music.volume = slider.value;
    }
    public void clickExit()
    {
        if (PausePanel.activeInHierarchy)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            PausePanel.SetActive(true);
        }
    }
    public void onclickQuit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
