using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    ObjectPooler objectPooler;
    CloundSpawner Leveldetector;
    float currentscore,currentscoreLV;
    public Transform Playerpos;
    public GameObject WarningSign;
    GameObject asteroid;
    int asteroidamount ;

    float pluscurrentscoreLV;

    private void Awake()
    {
        asteroidamount = 1;
        PlayerPrefs.SetFloat("CurrentScore", 0);
    }
    void Start()
    {
        currentscoreLV = 500;
        objectPooler = ObjectPooler.Instance;
  
    }
    void Update()
    {
        currentscore = PlayerPrefs.GetFloat("CurrentScore");
        Onlevelchange();
        if(currentscoreLV <= currentscore)
        {
            Spawn(asteroidamount);
            currentscoreLV += pluscurrentscoreLV + 200;
        }

    }

    void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            asteroid = objectPooler.SpawnFormPool("Asteroid", Playerpos.transform.position + new Vector3(0, 30f, 0f), Quaternion.identity, 1);
        }
       
    }
    
    void Onlevelchange()
    {
        Leveldetector = CloundSpawner.instance;


        if (Leveldetector.Level == 1)
        {
            asteroidamount = 1;
            pluscurrentscoreLV = 200;
        }
        if (Leveldetector.Level == 2)
        {
            asteroidamount = 1;
            pluscurrentscoreLV = 200;
        }
        if (Leveldetector.Level == 3)
        {
            asteroidamount = 1;
            pluscurrentscoreLV = 200;
        }
        if (Leveldetector.Level == 4)
        {
            asteroidamount = 1;
            pluscurrentscoreLV = 200;
        }
        if (Leveldetector.Level == 5)
        {
            asteroidamount = 1;
            pluscurrentscoreLV = 180;
        }
        if (Leveldetector.Level == 6)
        {
            asteroidamount = 2;
            pluscurrentscoreLV = 180;
        }
        if (Leveldetector.Level == 7)
        {
            asteroidamount = 2;
            pluscurrentscoreLV = 180;
        }
        if (Leveldetector.Level == 8)
        {
            asteroidamount = 2;
            pluscurrentscoreLV = 150;
        }
        if (Leveldetector.Level == 9)
        {
            asteroidamount = 2;
            pluscurrentscoreLV = 150;
        }
        if (Leveldetector.Level == 10)
        {
            asteroidamount = 2;
            pluscurrentscoreLV = 150;
        }

    }
}
