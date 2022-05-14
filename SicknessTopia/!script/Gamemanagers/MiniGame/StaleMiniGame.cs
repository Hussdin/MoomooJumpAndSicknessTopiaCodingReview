using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaleMiniGame : MonoBehaviour
{
    public static StaleMiniGame staleMiniGame;
    [SerializeField]
    GameObject Iced, Bandage,towel;
    public Vector3 offset;
    public int treatcount;
    private void Awake()
    {
        staleMiniGame = this;
        treatcount = 3;
    }
    public void onclickedIce()
    {
        PlayerPrefs.SetString("currenttool", "Ice");
        Iced.SetActive(true);
        Bandage.SetActive(false);
        towel.SetActive(false);
    }
    public void onclickedBandadge()
    {
        PlayerPrefs.SetString("currenttool", "Bandage");
        Iced.SetActive(false);
        Bandage.SetActive(true);
        towel.SetActive(false);
    }
    public void onclicktowel()
    {
        PlayerPrefs.SetString("currenttool", "Towel");
        Iced.SetActive(false);
        Bandage.SetActive(false);
        towel.SetActive(true);
    }

    private void Update()
    {
        Iced.transform.position = Input.mousePosition + offset;
        Bandage.transform.position = Input.mousePosition + offset;
        towel.transform.position = Input.mousePosition + offset;
    }
}
