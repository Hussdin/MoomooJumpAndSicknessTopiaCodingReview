using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    QueSystem QueSystem;
    private void Start()
    {
        QueSystem = QueSystem.Qsystem;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            if (other.gameObject.GetComponent<SpecialProfile>()!=null)
            {
                QueSystem.NQS(this.gameObject);
            }
            else
            {
                QueSystem.NQ(this.gameObject);
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Patient"))
        {
            other.transform.rotation = this.transform.rotation;
        }
    }
}
