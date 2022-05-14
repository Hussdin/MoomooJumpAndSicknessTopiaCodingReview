using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayAgainPanel : MonoBehaviour
{
    public GameObject Player,Panel;
    AdMobScript AdMobScript;
    SoundManager sound;
    public static PlayAgainPanel instance;
    [SerializeField]
    ParticleSystem reviveeffect;
    [SerializeField]
    Text Coin, sc, hs;

    private void Awake()
    {
        instance = this;
        AdMobScript = AdMobScript.instance;
        sound = SoundManager.soundManager;
    }
    public void OnclickPlayAgain()
    {
        AdMobScript = AdMobScript.instance;
        //play ads 
        AdMobScript.UserChoseToWatchGameOverRewardAds();
           
     }
    private void Update()
    {
        showInfo();
    }

    public void revive()
    {
        reviveeffect.Play();
        StartCoroutine(wait());

        Panel.SetActive(false);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        sound = SoundManager.soundManager;
        sound.playRevivesound();
        float jumpforce = 10;
        Player.GetComponent<Renderer>().enabled = true;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        Player.GetComponent<Rigidbody2D>().gravityScale = 1;

        Vector2 velocity = Player.GetComponent<Rigidbody2D>().velocity;
        velocity.y = jumpforce;
        velocity.x = 0;
        Player.GetComponent<Rigidbody2D>().velocity = velocity;

    }
    public void OnclickNothanks()
    {
        SceneManager.LoadScene("Startscene");
        PlayerPrefs.SetFloat("CurrentScore", 0);
    }
    void showInfo()
    {
        Coin.text = "Coin : " + PlayerPrefs.GetFloat("CurrentCoin");
        sc.text = "Score : " + PlayerPrefs.GetFloat("CurrentScore");
        hs.text = "HighScore : " + PlayerPrefs.GetFloat("HighScore");
    }
}
