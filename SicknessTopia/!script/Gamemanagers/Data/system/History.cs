using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{
    public static History history;
    [SerializeField]
    GameObject HistoryPanel, HistoryBoard,Historybox;
    private void Awake()
    {
        history = this;
    }

    public void createhistorybox(GameObject Patient)
    {
        GameObject newhistorybox = Instantiate(Historybox,HistoryBoard.transform.GetComponent<RectTransform>());
        newhistorybox.GetComponent<HistoryBoardBehavior>().getPatient(Patient);
        newhistorybox.transform.parent = HistoryBoard.transform;
    }

    public void openhistorypanel()
    {
        if (HistoryPanel.activeInHierarchy)
        {
            HistoryPanel.SetActive(false);
        }
        else
        {
            HistoryPanel.SetActive(true);
        }
    }
}
