using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehavior : MonoBehaviour
{
    MedicineTable medicineTable;
    SoundManager sound;

    [SerializeField]
    GameObject mypos,me;
    bool clicked;
    private void Start()
    {
        medicineTable = MedicineTable.medictable;
        sound = SoundManager.sound;
    }
    private void OnEnable()
    {
        me.gameObject.transform.position = mypos.transform.position;
        me.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    private void Update()
    {
        if (clicked)
        {
            if (clicked)
            {
                me.gameObject.transform.position = Input.mousePosition;
            }
            else
            {
                me.gameObject.transform.position = me.gameObject.transform.position;
            }
        }
    }
    public void onclickthi()
    {
        sound.playerPickupmed();
        clicked = !clicked;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 30;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Busket"))
        {
            if (!medicineTable.PotionsinBucket.Contains(me.gameObject.name))
            {
                medicineTable.PotionsinBucket.Add(me.gameObject.name);
            }
        }
        if (collision.gameObject.CompareTag("Table"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
    public void Reset()
    {
        me.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        me.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
        me.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        me.gameObject.transform.position = mypos.transform.position;
        me.gameObject.transform.rotation = mypos.transform.rotation;
    }
}
