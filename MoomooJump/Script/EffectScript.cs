using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    ObjectPooler op;
    void Start()
    {
        op = ObjectPooler.Instance;
        StartCoroutine(Disable());
        
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
}
