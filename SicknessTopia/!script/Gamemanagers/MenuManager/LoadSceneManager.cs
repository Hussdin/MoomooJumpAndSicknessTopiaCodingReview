using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField]
    Text save1, save2, save3, save4, save5;
    private void OnEnable()
    {
        save1.text = PlayerPrefs.GetString("SaveSlot1", "Empthy");
        save2.text = PlayerPrefs.GetString("SaveSlot2", "Empthy");
        save3.text = PlayerPrefs.GetString("SaveSlot3", "Empthy");
        save4.text = PlayerPrefs.GetString("SaveSlot4", "Empthy");
        save5.text = PlayerPrefs.GetString("SaveSlot5", "Empthy");
    }
    private void Update()
    {
        
    }

    void updatebtnName()
    {
        PlayerPrefs.SetString("SaveSlot1", "Empthy");
        PlayerPrefs.SetString("SaveSlot2", "Empthy");
        PlayerPrefs.SetString("SaveSlot3", "Empthy");
        PlayerPrefs.SetString("SaveSlot4", "Empthy");
        PlayerPrefs.SetString("SaveSlot5", "Empthy");
    }

    
}
