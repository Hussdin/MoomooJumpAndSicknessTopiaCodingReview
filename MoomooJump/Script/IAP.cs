using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour
{
    public Button btn;
    public Text txt;

    private void Update()
    {
        if (PlayerPrefs.GetString("RemoveAds") == "Purchases")
        {
            btn.interactable = false;
            txt.text = "Purchased";
        }
    }
    public void OnPurchaseComplete(Product product)
    {
        PlayerPrefs.SetString("RemoveAds", "Purchases");
    }

}
