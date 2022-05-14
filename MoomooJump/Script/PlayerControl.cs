using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
   public static PlayerControl playercontrol;
    private void Awake()
    {
        playercontrol = this;
    }
    void Update()
    {

        Playerositionfix();
    }

    void Playerositionfix()
    {
        if(transform.position.x >=1.8f)
        {
            transform.position = new Vector2(1.8f,transform.position.y);
        }
        if (transform.position.x <= -2.15f)
        {
            transform.position = new Vector2(-2.15f, transform.position.y);
        }
    }
    [SerializeField]
    GameObject Player,deathParticle;
    [SerializeField]
    AudioSource PlayerDie;
    public void onPlayerDie()
    {
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        PlayerDie.Play();
        Player.GetComponent<Renderer>().enabled = false;
        deathParticle.GetComponent<ParticleSystem>().Play();
    }
}
