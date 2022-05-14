using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    PlayAds runadscontrol;
    PlayerControl playerControl;
    [SerializeField]
    AudioSource asteroid;
    [SerializeField]
    GameObject WarningSign;
    bool onstart, alreadyplay;
    GameObject WS;

    private void Awake()
    {
        runadscontrol = PlayAds.runadscontrol;
        playerControl = PlayerControl.playercontrol;   
    }

    private void Start()
    {
        onstart = true;
        float posx = this.transform.position.x;
        WS = Instantiate(WarningSign, Camera.main.transform); ;
        WS.transform.position = new Vector2(posx, Camera.main.transform.position.y + 3);
    }
    private void OnEnable()
    {
        float posx = this.transform.position.x;
        if (onstart)
        {
            alreadyplay = false;
            WS = Instantiate(WarningSign, Camera.main.transform); ;
            WS.transform.position = new Vector2(posx, Camera.main.transform.position.y + 3);
        }
    }

    private void Update()
    {
        asteroid.pitch = Time.timeScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        runadscontrol = PlayAds.runadscontrol;
        playerControl = PlayerControl.playercontrol;
        if (collision.gameObject.CompareTag("Player"))
        {
           playerControl.onPlayerDie();
           runadscontrol = PlayAds.runadscontrol;
           runadscontrol.OnplayerDie();
        }
    }
    private void OnBecameVisible()
    {
        if (!alreadyplay)
        {
            alreadyplay = true;
            asteroid.Play();
            Destroy(WS);
        }
    }
   
}

