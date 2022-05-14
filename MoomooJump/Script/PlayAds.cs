using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAds : MonoBehaviour
{
    public GameObject PlayagainPlanel;
    public static PlayAds runadscontrol;
    PlayerControl playerControl;
    bool alreadywatchad;

    private void Awake()
    {
        alreadywatchad = false;
        runadscontrol = this;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerControl = PlayerControl.playercontrol;
            playerControl.onPlayerDie();
            OnplayerDie();
        }
    }
    public void OnplayerDie()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);

        if (alreadywatchad == false)
        {
            alreadywatchad = true;
            PlayagainPlanel.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Startscene");
            PlayerPrefs.SetFloat("CurrentScore", 0);
        }

    }
}
