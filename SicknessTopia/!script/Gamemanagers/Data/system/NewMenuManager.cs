using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewMenuManager : MonoBehaviour
{
    CurrentGameDatatoconfig savegame;
    LoadingScene scene;

    bool press;
    [SerializeField]
    GameObject Mainmenu, NewGamePanel, LoadGamePanel;

    [SerializeField]
    TMP_InputField Inputfield;
    private void Awake()
    {
        press = false;
    }
    private void Start()
    {
        savegame = CurrentGameDatatoconfig.savegame;
    }
    void Update()
    {
        checkanypress();
    }

    public void LoadGame()
    {
        if (LoadGamePanel.activeInHierarchy)
        {
            LoadGamePanel.SetActive(false);
        }
        else
        {
            LoadGamePanel.SetActive(true);
        }
    }
    public void NewGame()
    {
        if (NewGamePanel.activeInHierarchy)
        {
            NewGamePanel.SetActive(false);
        }
        else
        {
            NewGamePanel.SetActive(true);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    void checkanypress()
    {
        if (!press)
        {
            if (Input.anyKey)
            {
                Mainmenu.SetActive(true);
            }
        }
    }
    public void OnclickNewGame()
    {
        string savekey = Inputfield.text;
        savegame.savedata(savekey, "DefaultSave");
        PlayerPrefs.SetString("CurrentGame", savekey);
        scene = LoadingScene.scene;
        scene.Loadscene();
    }
}
