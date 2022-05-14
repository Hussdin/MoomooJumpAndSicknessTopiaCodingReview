using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Endpanel : MonoBehaviour
{
    CurrentGameDatatoconfig data;
    DayManagement daymanage;
    [SerializeField]
    TMP_Text Day, Money, Treated;
    private void Start()
    {
        data = CurrentGameDatatoconfig.savegame;
        daymanage = DayManagement.daymanage;
    }
    private void OnEnable()
    {
        data = CurrentGameDatatoconfig.savegame;
        daymanage = DayManagement.daymanage;

        Day.text = data.day.ToString();
        Money.text = "+" +data.money.ToString();
        Treated.text = "จำนวนคนไข้ที่รักษาไป : " + daymanage.todayTreat.ToString() + " คน";
    }
}
