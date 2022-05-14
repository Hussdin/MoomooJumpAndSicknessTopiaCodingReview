using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPickTestMinigame : MonoBehaviour
{
    [SerializeField]
    Image Cursor,pen,niddle;
    [SerializeField]
    Sprite milk, seafood, grass, bac, egg, dust,DrawedHand,Defaulthand;
    [SerializeField]
    GameObject Hand,Point;

    private void OnDisable()
    {
        Hand.GetComponent<Image>().sprite = Defaulthand;
        Hand.GetComponent<Button>().interactable = true;
        Point.SetActive(false);
    }
    public void penonhand()
    {
        if (PlayerPrefs.GetString("currenttool") == "Pen")
        {
            Hand.GetComponent<Image>().sprite = DrawedHand;
            Hand.GetComponent<Button>().interactable = false;
            Point.SetActive(true);
        }
    }
    public void Pen()
    {
        PlayerPrefs.SetString("currenttool","Pen");
        if (!pen.gameObject.activeInHierarchy)
        {
            pen.gameObject.SetActive(true);
            niddle.gameObject.SetActive(false);
            Cursor.gameObject.SetActive(false);
        }
        else
        {
            pen.gameObject.SetActive(false);
        }
        
    }
    public void Niddle()
    {
        PlayerPrefs.SetString("currenttool", "Niddle");
        if (!niddle.gameObject.activeInHierarchy)
        {
           pen.gameObject.SetActive(false);
           niddle.gameObject.SetActive(true);
           Cursor.gameObject.SetActive(false);
        }
        else
        {
            niddle.gameObject.SetActive(false);
        }
        
    }
    public void Milk()
    {
        PlayerPrefs.SetString("currenttool", "นมวัว");
        Cursor.sprite = milk;
        if (!Cursor.gameObject.activeInHierarchy)
        {
            pen.gameObject.SetActive(false);
            niddle.gameObject.SetActive(false);
            Cursor.gameObject.SetActive(true);
        }
        else
        {
            Cursor.gameObject.SetActive(false);
        }
       
    }
    public void Seafood()
    {
        PlayerPrefs.SetString("currenttool", "อาหารทะเล");
        Cursor.sprite = seafood;
        if (!Cursor.gameObject.activeInHierarchy)
        {
            pen.gameObject.SetActive(false);
            niddle.gameObject.SetActive(false);
            Cursor.gameObject.SetActive(true);
        }
        else
        {
            Cursor.gameObject.SetActive(false);
        }
    }
    public void Grass()
    {
        PlayerPrefs.SetString("currenttool", "เกสรหญ้า");
        Cursor.sprite = grass;
        if (!Cursor.gameObject.activeInHierarchy)
        {
            pen.gameObject.SetActive(false);
            niddle.gameObject.SetActive(false);
            Cursor.gameObject.SetActive(true);
        }
        else
        {
            Cursor.gameObject.SetActive(false);
        }
    }
    public void Bac()
    {
        PlayerPrefs.SetString("currenttool", "เชื้อรา");
        Cursor.sprite = bac;
        if (!Cursor.gameObject.activeInHierarchy)
        {
            pen.gameObject.SetActive(false);
            niddle.gameObject.SetActive(false);
            Cursor.gameObject.SetActive(true);
        }
        else
        {
            Cursor.gameObject.SetActive(false);
        }
    }
    public void Egg()
    {
        PlayerPrefs.SetString("currenttool", "ไข่");
        Cursor.sprite = egg;
        if (!Cursor.gameObject.activeInHierarchy)
        {
            pen.gameObject.SetActive(false);
            niddle.gameObject.SetActive(false);
            Cursor.gameObject.SetActive(true);
        }
        else
        {
            Cursor.gameObject.SetActive(false);
        }
    }
    public void Dust()
    {
        PlayerPrefs.SetString("currenttool", "ไรฝุ่น");
        Cursor.sprite = dust;
        if (!Cursor.gameObject.activeInHierarchy)
        {
            pen.gameObject.SetActive(false);
            niddle.gameObject.SetActive(false);
            Cursor.gameObject.SetActive(true);
        }
        else
        {
            Cursor.gameObject.SetActive(false);
        }
    }

}
