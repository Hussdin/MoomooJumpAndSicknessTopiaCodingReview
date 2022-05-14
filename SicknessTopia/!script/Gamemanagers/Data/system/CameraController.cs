using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject GeneralRoomCamera;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GeneralRoom"))
        {
            GeneralRoomCamera.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GeneralRoom"))
        {
            GeneralRoomCamera.SetActive(false);
        }
    }
}
