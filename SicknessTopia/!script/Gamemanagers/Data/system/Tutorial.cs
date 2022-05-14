using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
    [SerializeField]
    GameObject tutorialPanel;
    [SerializeField]
    Image TutorialImage;
    [SerializeField]
    Sprite controller, UI, Tips, Med, Map, Method,Result;

    int page;
    private void Awake()
    {
        page = 1;
        checkFirstPlay();
        changePage();
    }
    void checkFirstPlay()
    {
        string key = PlayerPrefs.GetString("CurrentGame");
        int condition = PlayerPrefs.GetInt(key);
        if ( condition == 0)
        {
            PlayerPrefs.SetInt(key, 1);
            tutorialPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void OpenTutorial()
    {
        if (tutorialPanel.activeInHierarchy)
        {
            tutorialPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            tutorialPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void nextpage()
    {
        if(page < 7)
        {
            page++;
        }
        changePage();
    }
    public void prevpage()
    {
        if (page > 1)
        {
            page--;
        }
        changePage();
    }
    void changePage()
    {
        switch (page)
        {
            case 1:
                TutorialImage.sprite = controller;
                break;
            case 2:
                TutorialImage.sprite = UI;
                break;
            case 3:
                TutorialImage.sprite = Map;
                break;
            case 4:
                TutorialImage.sprite = Med;
                break;
            case 5:
                TutorialImage.sprite = Method;
                break;
            case 6:
                TutorialImage.sprite = Result;
                break;
            case 7:
                TutorialImage.sprite = Tips;
                break;
        }
    }
}
