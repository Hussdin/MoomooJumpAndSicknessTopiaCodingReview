using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sound;
    [SerializeField]
    public AudioSource BG,Door,Announce,QuestDone,Interact,Heart,NormalLung,BadLung,LoadingSound
        ,minigamesuccess,PickupMed,Checkout,talk1,talk2,talk3,siren,paper,pouring,bandagr,tape,push;

    public List<AudioSource> talksound = new List<AudioSource>();
    void addtalksound()
    {
        talksound.Add(talk1);
        talksound.Add(talk2);
        talksound.Add(talk3);
    }
    private void Awake()
    {
        sound = this;
        addtalksound();
    }
    public void playtalksound()
    {
        int ran = Random.Range(0,talksound.Count);
        talksound[ran].Play();
    }
    public void playerDoor()
    {
        Door.Play();
    }
    public void PLayAnnounce()
    {
        Announce.Play();
    }
    public void PLayQuestdone()
    {
        QuestDone.Play();
    }
    public void PLayInteract()
    {
        Interact.Play();
    }
    public void playHerat()
    {
        Heart.Play();
    }
    public void playNLung()
    {
        NormalLung.Play();
    }
    public void playBLung()
    {
        BadLung.Play();
    }
    public void PlayLoading()
    {
        LoadingSound.Play();
    }
    public void PlayeMinigameSuccess()
    {
        minigamesuccess.Play();
    }
    public void playerPickupmed()
    {
        PickupMed.Play();
    }
    public void PlayCheckout()
    {
        Checkout.Play();
    }
}
