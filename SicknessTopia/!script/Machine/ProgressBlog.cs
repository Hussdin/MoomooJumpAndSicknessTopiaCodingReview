using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ProgressBlog : MonoBehaviour
{
    public static ProgressBlog progressBlog;
    [SerializeField]
    TMP_Text Head;
    [SerializeField]
    Image Img;
    [SerializeField]
    Sprite Doneimg;
    [SerializeField]
    GameObject This;

    string Mode;
    private void Awake()
    {
        progressBlog = this;
    }
    private void Update()
    {
        checkmode();
    }
    public void UpdateBoard(string mode)
    {
        Mode = mode;
    }
    void checkmode()
    {
        switch (Mode)
        {
            default:
                This.gameObject.SetActive(false);
                break;
            case "High":
                Head.text = "วัดส่วนสูง ชั่งน้ำหนัก";
                This.gameObject.SetActive(true);
                break;
            case "Weight":
                Head.text = "ชั่งน้ำหนัก";
                This.gameObject.SetActive(true);
                break;
            case "BP":
                Head.text = "วัดความดัน";
                This.gameObject.SetActive(true);
                break;
            case "Xray":
                Head.text = "X-ray ปอด";
                This.gameObject.SetActive(true);
                break;
            case "Liquid":
                Head.text = "เก็บตัวอย่างเสมหะ";
                This.gameObject.SetActive(true);
                break;
            case "Lab":
                Head.text = "ตรวจสาร";
                This.gameObject.SetActive(true);
                break;
            case "":
                This.gameObject.SetActive(false);
                break;
        }
    }
    public void Reset()
    {
        Head.text = "";
    }
}
