using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    GameObject animationstart,Shop,StartBTN;
    SoundManager soundManager;
    private void Start()
    {
        soundManager = SoundManager.soundManager;
    }
    public void oclickstart()
    {
        Shop.GetComponent<Animator>().SetBool("Start", true);
    }
    [SerializeField]
    GameObject player, clound;
    void playAnim()
    {
        player.gameObject.SetActive(false);
        clound.gameObject.SetActive(false);
        StartBTN.SetActive(false);

        animationstart.SetActive(true);
        animationstart.GetComponent<Animator>().SetBool("Start", true);
    }

    public void changescene()
    {
        soundManager.playchangescenesound();
        SceneManager.LoadScene(1);
        Shop.GetComponent<Animator>().SetBool("Start", false);
        animationstart.GetComponent<Animator>().SetBool("Start", false);
    }
}
