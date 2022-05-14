using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    ObjectPooler objectPooler;

    public AudioSource collect;
    StatusScript status;

    [SerializeField]
    float UltimateGate;
    float maxultimategate;
    float boostforce;

    public Sprite ufo,Player;
    Animator anim;
    Rigidbody2D rb;

    public GameObject R, Y, G;
    public GameObject BoostPrticle;

    private void Awake()
    {
        status = StatusScript.status;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        maxultimategate = 3;
    }

    private void Update()
    {
        boostforce = status.Boostforce;
        CheckUltimate();
        changeTagWhenStopBoost();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Nitros"))
        {
            UltimateGate++;
            collision.gameObject.SetActive(false);
            objectPooler = ObjectPooler.Instance;
            objectPooler.Addqueue(collision.gameObject.tag, collision.gameObject);
            collect.Play();
        }
    }

    void CheckUltimate()
    {
        if (UltimateGate != 0)
        {
            if(UltimateGate == 1)
            {
                R.gameObject.SetActive(true);
            }
            if (UltimateGate == 2)
            {
                Y.gameObject.SetActive(true);
            }
            if (UltimateGate == 3)
            {
                G.gameObject.SetActive(true);
            }
        }
        else
        {
            R.gameObject.SetActive(false);
            Y.gameObject.SetActive(false);
            G.gameObject.SetActive(false);
        }

        if(UltimateGate == maxultimategate)
        {
            rb.velocity = Vector2.up * boostforce;
            anim.SetBool("Boosted", true);
            this.gameObject.tag = "UltimateBoost";
            BoostPrticle.SetActive(true);
            UltimateGate = 0;
        }
    }

    void changeTagWhenStopBoost()
    {
        if (rb.velocity.y <= 0)
        {
            anim.SetBool("Boosted", false);
            BoostPrticle.SetActive(false);
            this.gameObject.tag = "Player";
        }
    }
}
