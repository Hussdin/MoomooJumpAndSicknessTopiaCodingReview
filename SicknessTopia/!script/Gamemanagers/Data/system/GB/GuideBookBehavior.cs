using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GuideBookBehavior : MonoBehaviour
{
    SoundManager sound;
    [SerializeField]
    GameObject BYello, BGreen, BOrange, BBlue, BPurple, RYello, RGreen, Rred, RBlue,nextpage,prevPage;
    [SerializeField]
    Image Bookpage;
    [SerializeField]
    Sprite Ypage, Gpage, Opage, Bpage, Ppage, RYpage, RRpage, RGpage, RBpage,G2page,P2page;

    [SerializeField]
    GameObject GB, Inner;

    string page;
    private void Start()
    {
        sound = SoundManager.sound;
    }
    private void Update()
    {
        CheckWhichPage();
        checkdisablenextpagebtn();
    }
    void CheckWhichPage()
    {
        page = PlayerPrefs.GetString("GuideBookPage","Yello");
        switch (page)
        {
            default:
                break;

            case "Yello":
                BYello.SetActive(true);
                Bookpage.sprite = Ypage;
                break;
            case "Orange":
                BOrange.SetActive(true);
                Bookpage.sprite = Opage;
                break;
            case "Blue":
                BBlue.SetActive(true);
                Bookpage.sprite = Bpage;
                break;
            case "Green":
                BGreen.SetActive(true);
                Bookpage.sprite = Gpage;
                break;
            case "Purple":
                BPurple.SetActive(true);
                Bookpage.sprite = Ppage;
                break;
            case "RYello":
                RYello.SetActive(true);
                Bookpage.sprite = RYpage;
                break;
            case "RGreen":
                RGreen.SetActive(true);
                Bookpage.sprite = RGpage;
                break;
            case "Rred":
                Rred.SetActive(true);
                Bookpage.sprite = RRpage;
                break;
            case "RBlue":
                RBlue.SetActive(true);
                Bookpage.sprite = RBpage;
                break;
        }
    }
    public void onclicknextPage()
    {
        string currentpage = PlayerPrefs.GetString("GuideBookPage", "Yello");
        sound.paper.Play();
        switch (currentpage)
        {
            default:
                break;
            case "Green":
                PlayerPrefs.SetString("GuideBookPage", "G2");
                Bookpage.sprite = G2page;
                break;
            case "Purple":
                PlayerPrefs.SetString("GuideBookPage", "P2");
                Bookpage.sprite = P2page;
                break;
        }
    }
    public void onclickPrevPage()
    {
        string currentpage = PlayerPrefs.GetString("GuideBookPage");
        sound.paper.Play();
        switch (currentpage)
        {
            default:
                break;
            case "G2":
                PlayerPrefs.SetString("GuideBookPage", "Green");
                Bookpage.sprite = Gpage;
                break;
            case "P2":
                PlayerPrefs.SetString("GuideBookPage", "Purple");
                Bookpage.sprite = Ppage;
                break;
        }
    }

    void checkdisablenextpagebtn()
    {
        if (page == "Green" || page == "Purple")
        {
            nextpage.GetComponent<Button>().interactable = true;
            prevPage.GetComponent<Button>().interactable = false;
        }
        else if(page == "G2" || page == "P2")
        {
            nextpage.GetComponent<Button>().interactable = false;
            prevPage.GetComponent<Button>().interactable = true;
        }
        else
        {
            nextpage.GetComponent<Button>().interactable = false;
            prevPage.GetComponent<Button>().interactable = false;
        }
    }

    public void onclickGBIcon()
    {
        sound.paper.Play();
        if (GB.activeInHierarchy)
        {
            GB.SetActive(false);
        }
        else
        {
            GB.SetActive(true);
        }
    }
    public void onclickGB()
    {
        sound.paper.Play();
        if (Inner.activeInHierarchy)
        {
            Inner.SetActive(false);
        }
        else
        {
            Inner.SetActive(true);
        }
    }
    public void onclickBD()
    {
        sound.paper.Play();
        Inner.SetActive(false);
    }
}
