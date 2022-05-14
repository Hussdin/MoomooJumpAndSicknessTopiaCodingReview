using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBehavior : MonoBehaviour
{
    SoundManager sound;
    [SerializeField]
    GameObject Map;
    private void Start()
    {
        sound = SoundManager.sound;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OnclickMap();
        }
    }
    public void OnclickMap()
    {
        sound.PLayInteract();
        if (Map.activeInHierarchy)
        {
            Map.SetActive(false);
        }
        else
        {
            Map.SetActive(true);
        }
    }
}
