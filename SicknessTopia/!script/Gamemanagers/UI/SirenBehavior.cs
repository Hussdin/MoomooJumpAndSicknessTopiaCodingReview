using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SirenBehavior : MonoBehaviour
{
    [SerializeField]
    Image Siren;
    [SerializeField]
    Sprite On, Off;

    bool on;
    private void OnEnable()
    {
        InvokeRepeating("changecondition", 0, 0.5f);
    }
    private void OnDisable()
    {
        CancelInvoke("changecondition");
    }
    private void Update()
    {
        changeSprite();
    }
    void changeSprite()
    {
        if (on)
        {
            Siren.sprite = On;
        }
        else
        {
            Siren.sprite = Off;
        }
    }
    void changecondition()
    {
        on = !on;
    }
}
