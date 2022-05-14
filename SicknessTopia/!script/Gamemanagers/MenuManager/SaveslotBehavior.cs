using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveslotBehavior : MonoBehaviour
{
    LoadingScene scene;
    [SerializeField]
    TMP_Text Savename, Day;
    public void GetSaveInfo()
    {
        Savename.text = this.gameObject.name;

        CurrentData data = SaveSystem.LoadSave(Savename.text);
        Day.text = data.Day.ToString();

    }

    public void onclickbin()
    {
        SaveSystem.DeleteSave(this.gameObject.name);
        Destroy(this.gameObject);
    }

    public void onclickthis()
    {
        PlayerPrefs.SetString("CurrentGame",this.gameObject.name);
        scene = LoadingScene.scene;
        scene.Loadscene();
    }
}
