using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public GameObject SettingPanel,SettingButton;
    bool ismute = false;
    SoundManager soundManager;
    void Start()
    {
        soundManager = SoundManager.soundManager;
        SettingPanel.SetActive(false);
        ismute = PlayerPrefs.GetInt("MUTE") == 1;
        AudioListener.pause = ismute;
    }
    private void Update()
    {
        checkswitchcontrolsetting();
    }
    public void Opensetting()
    {
        soundManager.playbuttonsound();
        SettingButton.GetComponent<Animator>().SetTrigger("Touch");
        if (SettingPanel.activeInHierarchy)
        {
            soundManager.playchangescenesound();
            SettingPanel.GetComponent<Animator>().SetBool("Touchsetting", false);
            StartCoroutine(closesetting());
        }
        else
        {
            soundManager.playchangescenesound();
            SettingPanel.SetActive(true);
            SettingPanel.GetComponent<Animator>().SetBool("Touchsetting", true);
            
        }
    }
    IEnumerator closesetting()
    {
        yield return new WaitForSeconds(0.2f);
        SettingPanel.SetActive(false);

    }
    public void OpensettingPlayscene()
    {
        soundManager.playbuttonsound();
        SettingButton.GetComponent<Animator>().SetTrigger("Touch");
        if (SettingPanel.activeInHierarchy)
        {
            soundManager.playchangescenesound();
            SettingPanel.GetComponent<Animator>().SetBool("Touchsetting", false);
            StartCoroutine(closesetting());
            Time.timeScale = 1;
        }
        else
        {
            soundManager.playchangescenesound();
            SettingPanel.SetActive(true);
            SettingPanel.GetComponent<Animator>().SetBool("Touchsetting", true);
            Time.timeScale = 0;
        }
    }
    public Image Mute;
    public Text Mutetxt;
    public Sprite mute, unmute;
    public void MusicMute()
    {
        if (!ismute)
        {
            Mutetxt.text = "UNMUTE";
            Mute.sprite = unmute;
        }
        else
        {
            Mutetxt.text = "MUTE";
            Mute.sprite = mute;
        }

        soundManager.playbuttonsound();
        ismute = !ismute;
        AudioListener.pause = ismute;
        PlayerPrefs.SetInt("MUTE", ismute ? 1 : 0);
    }

    public Image checktilt, checkdrag;
    public void OnclickTilt()
    {
        soundManager.playbuttonsound();
        PlayerPrefs.SetString("control", "tilt");
        checktilt.gameObject.SetActive(true);
        checkdrag.gameObject.SetActive(false);
    }
    public void OnclickJoystick()
    {
        soundManager.playbuttonsound();
        PlayerPrefs.SetString("control", "drag");
        checktilt.gameObject.SetActive(false);
        checkdrag.gameObject.SetActive(true);
    }
    void checkswitchcontrolsetting()
    {
        if(PlayerPrefs.GetString("control")== "tilt")
        {
            checktilt.gameObject.SetActive(true);
            checkdrag.gameObject.SetActive(false);
        }
        else
        {
            checktilt.gameObject.SetActive(false);
            checkdrag.gameObject.SetActive(true);
        }
    }
}
