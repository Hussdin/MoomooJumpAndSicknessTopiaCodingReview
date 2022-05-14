using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pinbehavior : MonoBehaviour
{
    SoundManager sound;
    [SerializeField]
    GameObject Book,RYello, RGreen, Rred, RBlue;
    [SerializeField]
    GameObject BYello, BGreen, BOrange, BNlue, BPurple;
    [SerializeField]
    Sprite Ypage, Gpage, Opage, Bpage, Ppage,RYpage,RRpage,RGpage,RBpage;
    private void Start()
    {
        sound = SoundManager.sound;
    }
    public void ONCLICKTHIS()
    {
        sound.paper.Play();
        string key = this.gameObject.name;
        switch (key)
        {
            case "Yello":
                BYello.SetActive(true);///////////
                BGreen.SetActive(false);
                BOrange.SetActive(false);
                BNlue.SetActive(false);
                BPurple.SetActive(false);

                RYello.SetActive(false);
                RGreen.SetActive(false);
                Rred.SetActive(false);
                RBlue.SetActive(false);

                PlayerPrefs.SetString("GuideBookPage", "Yello");

                break;
            case "Green":
                BYello.SetActive(false);
                BGreen.SetActive(true); ///////
                BOrange.SetActive(false);
                BNlue.SetActive(false);
                BPurple.SetActive(false);

                PlayerPrefs.SetString("GuideBookPage", "Green");
                break;
            case "Orange":
                BYello.SetActive(false);
                BGreen.SetActive(false);
                BOrange.SetActive(true);////////////
                BNlue.SetActive(false);
                BPurple.SetActive(false);
                PlayerPrefs.SetString("GuideBookPage", "Orange");
                break;
            case "Blue":
                BYello.SetActive(false);
                BGreen.SetActive(false);
                BOrange.SetActive(false);
                BNlue.SetActive(true);////////////
                BPurple.SetActive(false);

                PlayerPrefs.SetString("GuideBookPage", "Blue");
                break;
            case "Purple":
                BYello.SetActive(false);
                BGreen.SetActive(false);
                BOrange.SetActive(false);
                BNlue.SetActive(false);
                BPurple.SetActive(true);///////////////

                PlayerPrefs.SetString("GuideBookPage", "Purple");
                break;

            case "RYello":
                BYello.SetActive(false);
                BGreen.SetActive(false);
                BOrange.SetActive(false);
                BNlue.SetActive(false);
                BPurple.SetActive(false);

                RYello.SetActive(true);////////////
                RGreen.SetActive(false);
                Rred.SetActive(false);
                RBlue.SetActive(false);

                PlayerPrefs.SetString("GuideBookPage", "RYello");

                break;

            case "RGreen":
                BYello.SetActive(false);
                BGreen.SetActive(false);
                BOrange.SetActive(false);
                BNlue.SetActive(false);
                BPurple.SetActive(false);

                RYello.SetActive(false);
                RGreen.SetActive(true);
                Rred.SetActive(false);
                RBlue.SetActive(false);

                PlayerPrefs.SetString("GuideBookPage", "RGreen");

                break;

            case "RRed":
                BYello.SetActive(false);
                BGreen.SetActive(false);
                BOrange.SetActive(false);
                BNlue.SetActive(false);
                BPurple.SetActive(false);

                RYello.SetActive(false);
                RGreen.SetActive(false);
                Rred.SetActive(true);
                RBlue.SetActive(false);

                PlayerPrefs.SetString("GuideBookPage", "Rred");

                break;

            case "RBlue":
                BYello.SetActive(false);
                BGreen.SetActive(false);
                BOrange.SetActive(false);
                BNlue.SetActive(false);
                BPurple.SetActive(false);

                RYello.SetActive(false);
                RGreen.SetActive(false);
                Rred.SetActive(false);
                RBlue.SetActive(true);

                PlayerPrefs.SetString("GuideBookPage", "RBlue");

                break;


        }
    }

}
