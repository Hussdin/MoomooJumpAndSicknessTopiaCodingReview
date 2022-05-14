using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorToolBehavior : MonoBehaviour
{
    public Vector3 offset;
    [SerializeField]
    GameObject Minigamepanel;
    private void Awake()
    {
        this.transform.position = Input.mousePosition + offset;
    }
    void Update()
    {
        setOffset(PlayerPrefs.GetString("currenttool"));
        this.transform.position = Input.mousePosition + offset;
    }
    void setOffset(string key)
    {
        if(this.gameObject.name != "Hand")
        {
            switch (key)
            {
                case "Stethoscope":
                    offset = new Vector3(-60, -50, 0);
                    break;
                case "Thermometer":
                    offset = new Vector3(180, -90, 0);
                    break;
                case "Flashlight":
                    offset = new Vector3(-200, -100, 0);
                    break;
                case "Pen":
                    offset = new Vector3(0, 0, 0);
                    break;
                case "Niddle":
                    offset = new Vector3(0, -150, 0);
                    break;
                case "Milk":
                    offset = new Vector3(0, 0, 0);
                    break;

            }
        }
       
    }
}
