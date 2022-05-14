using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    GameObject pos1, pos2, pos3,pos0;
    Vector3 desirepos;
    public int startpos;
    private void Awake()
    {
        SetStartMove();
    }
    void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, desirepos, 10*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pos0"))
        {
            desirepos = pos1.transform.position;
            plusradius();
        }
        if (other.gameObject.CompareTag("Pos1"))
        {
            desirepos = pos2.transform.position;
            plusradius();
        }
        if (other.gameObject.CompareTag("Pos2"))
        {
            desirepos = pos3.transform.position;
            plusradius();
        }
        if (other.gameObject.CompareTag("Pos3"))
        {
            desirepos = pos0.transform.position;
            plusradius();
        }
    }
    void plusradius()
    {
        this.gameObject.transform.Rotate(0, this.transform.rotation.y + 90, 0); 
    }
    
    void SetStartMove()
    {
        switch (startpos)
        {
            default:
                break;
            case 1:
                desirepos = pos1.transform.position;
                break;
            case 2:
                desirepos = pos2.transform.position;
                break;
            case 3:
                desirepos = pos3.transform.position;
                break;
            case 4:
                desirepos = pos0.transform.position;
                break;

        }
    }
}
