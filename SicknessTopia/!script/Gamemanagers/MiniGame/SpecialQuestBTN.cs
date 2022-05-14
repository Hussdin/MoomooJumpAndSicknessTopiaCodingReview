using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialQuestBTN : MonoBehaviour
{
    private void OnDisable()
    {
        Destroy(this.gameObject);
    }
}
