using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager minigamemanager;
    [SerializeField]
    GameObject MainminigamePanel,EyeGamePanel, TroatGamePanel, ListeningGamePanel, TempGamePanel,MiniGameBlog,Bodycam,askingPanel;
    [SerializeField]
    Sprite DefaultButton,DoneButton,Mouth0,Mouth1,Mouth2;
    [SerializeField]
    Button Eye, Troat, Listening, Temp;
    [SerializeField]
    Image Mouth;
    [SerializeField]
    GameObject Ste, Tempper, Flash;
    [SerializeField]
    GameObject b1, b2, b3, b4, b5, b6,b7,b8;
    private void Awake()
    {
        minigamemanager = this;
    }
    public void onclickEyeGame()
    {
        PlayerPrefs.SetString("MiniGameMode", "Eye");
        MainminigamePanel.SetActive(true);
        EyeGamePanel.SetActive(true);
        TroatGamePanel.SetActive(false);
        ListeningGamePanel.SetActive(false);
        TempGamePanel.SetActive(false);
    }
    public void onclickTroatGame()
    {
        PlayerPrefs.SetString("MiniGameMode", "Troat");
        MainminigamePanel.SetActive(true);
        TroatGamePanel.SetActive(true);
        EyeGamePanel.SetActive(false);
        ListeningGamePanel.SetActive(false);
        TempGamePanel.SetActive(false);
    }
    public void onClickListeningGame()
    {
        PlayerPrefs.SetString("MiniGameMode", "Listening");
        MainminigamePanel.SetActive(true);
        EyeGamePanel.SetActive(false);
        TroatGamePanel.SetActive(false);
        ListeningGamePanel.SetActive(true);
        TempGamePanel.SetActive(false);
    }
    public void onClickTempGame()
    {
        PlayerPrefs.SetString("MiniGameMode", "Temp");
        MainminigamePanel.SetActive(true);
        EyeGamePanel.SetActive(false);
        TroatGamePanel.SetActive(false);
        ListeningGamePanel.SetActive(false);
        TempGamePanel.SetActive(true);
    }

    public void SetToDone(string key, string disease)
    {
        switch (key)
        {
            case "Eye":
                Eye.GetComponent<Image>().sprite = DoneButton;
                Eye.GetComponent<Button>().interactable = false;
                break;
            case "Troat":
                Troat.GetComponent<Image>().sprite = DoneButton;
                Troat.GetComponent<Button>().interactable = false;
                if(disease == "ไข้หวัดคออักเสบ(เชื้อไวรัส)")
                {
                    Mouth.sprite = Mouth2;
                }
                else if(disease == "ไข้หวัดคออักเสบ(เชื้อแบคทีเรีย)")
                {
                    Mouth.sprite = Mouth1;
                }
                else
                {
                    Mouth.sprite = Mouth0;
                }
                break;
            case "Listening":
                Listening.GetComponent<Image>().sprite = DoneButton;
                Listening.GetComponent<Button>().interactable = false;
                ListeningGamePanel.SetActive(false);
                break;
            case "Temp":
                Temp.GetComponent<Image>().sprite = DoneButton;
                Temp.GetComponent<Button>().interactable = false;
                break;
        }
    }
    public void ResetButton(GameObject button)
    {
        button.GetComponent<Image>().sprite = DefaultButton;
        button.GetComponent<Button>().interactable = false;
    }
    void setdefaultbtn()
    {
        b1.SetActive(true);
        b2.SetActive(true);
        b3.SetActive(true);
        b4.SetActive(true);
        b5.SetActive(true);
        b6.SetActive(true);
        b7.SetActive(true);
        b8.SetActive(true);
    }
    public void closeMinigamePanel()
    {
        Ste.SetActive(false);
        Flash.SetActive(false);
        Tempper.SetActive(false);
        setdefaultbtn();
        MiniGameBlog.SetActive(false);
        Bodycam.SetActive(false);
        askingPanel.SetActive(true);
        MainminigamePanel.SetActive(false);
    }
}
