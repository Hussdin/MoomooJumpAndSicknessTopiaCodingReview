using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryBoxSlotBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject InfoPanel,Pos;
    private void Awake()
    {
        Pos = GameObject.FindGameObjectWithTag("BoardPos");
    }
    public void showinfo()
    {
        InfoPanel.SetActive(true);
        InfoPanel.transform.position = Pos.transform.position;
    }
    public void closeInfo()
    {
        InfoPanel.SetActive(false);
    }
}
