using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music,Button,ChangeScene,Coin,r1,r2;
    public static SoundManager soundManager;
    private void Update()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    private void Awake()
    {
        soundManager = this;
        Music.Play();
    }
    public void playbuttonsound()
    {
        Button.Play();
    }
    public void playchangescenesound()
    {
        ChangeScene.Play();
    }
    public void playCoinsound()
    {
        Coin.pitch = Time.timeScale;
        Coin.Play();
    }
    public void playRevivesound()
    {
        r1.Play();
        r2.Play();
    }
}
