using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    ObjectPooler objpool;
    float currentscore, currentscoreLV;
    public Transform Playerpos;
    StatusScript status;
    private void Start()
    {
        status = StatusScript.status;
        currentscoreLV = 100;
        objpool = ObjectPooler.Instance;
    }
    void Update()
    {
        currentscore = PlayerPrefs.GetFloat("CurrentScore",0);
        if (currentscoreLV <= currentscore)
        {
            Spawn();
            currentscoreLV += status.ItemSpawnRate;
        }
    }

    void Spawn()
    {
        objpool.SpawnFormPool("Nitros", Playerpos.transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity,1);
    }

    void checkBoostforceLV()
    {
       
    }
}
