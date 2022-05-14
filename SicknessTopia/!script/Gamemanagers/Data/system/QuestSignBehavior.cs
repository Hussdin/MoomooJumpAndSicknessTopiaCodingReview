using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestSignBehavior : MonoBehaviour
{
    public GameObject sign;
    public void checkQueststatus()
    {
        if (this.GetComponent<Image>().sprite.name == "Pack1_5")
        {
            sign.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        Destroy(sign);
    }
}
