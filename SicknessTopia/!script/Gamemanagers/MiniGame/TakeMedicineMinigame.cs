using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMedicineMinigame : MonoBehaviour
{
    [SerializeField]
    GameObject Med1, Med2;
    int mode;
    private void OnEnable()
    {
        mode = PlayerPrefs.GetInt("Med");
        checkmed();
    }

    void checkmed()
    {
        if(mode == 1)
        {
            Med1.SetActive(true);
            Med2.SetActive(false);
        }
        else
        {
            Med1.SetActive(false);
            Med2.SetActive(true);
        }
    }

}
