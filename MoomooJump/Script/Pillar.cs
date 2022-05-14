using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pillar : MonoBehaviour
{
    ObjectPooler objectPooler;
    CloundSpawner Leveldetector;
    StatusScript status;
    PlayAds runadscontrol;
    PlayerControl playerControl;
    int STR;
    float changelv;
    private void Awake()
    {
        STR = 1;
        changelv = 3150;
    }
    private void Start()
    {
        status = StatusScript.status;
    }
    private void Update()
    {
        checklevel();
        if(status.STR > STR)
        {

            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {

            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        runadscontrol = PlayAds.runadscontrol;
        playerControl = PlayerControl.playercontrol;
        objectPooler = ObjectPooler.Instance;
        status = StatusScript.status;
        if (collision.gameObject.CompareTag("Player") && JumpingPhysic.isfalling == false)
        {
            if (status.STR > this.STR)
            {
                gameObject.SetActive(false);
                objectPooler.Addqueue(this.gameObject.tag, this.gameObject);
            }
            else
            {
                playerControl.onPlayerDie();
                runadscontrol = PlayAds.runadscontrol;
                runadscontrol.OnplayerDie();
            }
        }
    }

    void checklevel()
    {
        Leveldetector = CloundSpawner.instance;
        if (Leveldetector.currentscore >= changelv)
        {
            changelv += 1000;
            STR += 1;
        }
    }
}
