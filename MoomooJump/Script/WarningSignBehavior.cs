using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSignBehavior : MonoBehaviour
{
    public AudioSource alert;
    bool alreadyplay;
    void Update()
    {
        alert.pitch = Time.timeScale;
        if (gameObject.activeInHierarchy )
        {
            if (!alreadyplay)
            {
                alreadyplay = true;
                alert.Play();
            }
        }
    }
}
