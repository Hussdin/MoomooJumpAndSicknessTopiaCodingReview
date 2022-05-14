using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class LoadedSavename : MonoBehaviour
{
    [SerializeField]
    GameObject slot,slotarea;
    List<string> savenamelist = new List<string>();
    private void Awake()
    {
        getfliename();
        createsaveslot();
    }
    public void getfliename()
    {
        var folder = Directory.CreateDirectory(Application.persistentDataPath + "/Save");
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/Save/");
        //DirectoryInfo dir = new DirectoryInfo("Assets/!Assets/SaveData/");
        FileInfo[] info = dir.GetFiles();
        
        for (int i = 0; i < info.Length; i++)
        {
            string filename = info[i].Name;
            savenamelist.Add(filename);
        }
    }

    void createsaveslot()
    {
        for (int i = 0; i < savenamelist.Count; i++)
        {
            GameObject newslot = Instantiate(slot, slotarea.GetComponent<RectTransform>());
            newslot.gameObject.name = savenamelist[i];
            newslot.GetComponent<SaveslotBehavior>().GetSaveInfo();
        } 
    }
}
