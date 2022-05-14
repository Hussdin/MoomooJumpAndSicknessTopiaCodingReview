using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloundSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public static CloundSpawner instance;
    public GameObject ObjPointtospawn;
    private Vector2 SpawnPos;
    public int Level;
    public float currentscore;
    string tagtospawn;
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        SpawnPos = new Vector2(0,0);
        SpawnClound();
    }
    private void Awake()
    {
        instance = this;
        Level = 1;
        currentscore = PlayerPrefs.GetFloat("CurrentScore");
    }

    private void Update()
    {
        currentscore = PlayerPrefs.GetFloat("CurrentScore");
        UpdateLevel();
    }

    void SpawnClound()
    {
        if(Level == 1)
        {
             int count = 10;
             for (int i = 0; i < count; i++)
             {
                  objectPooler.SpawnFormPool("Clound",new Vector2(Random.Range(-1.8f, 2.5f),SpawnPos.y), Quaternion.identity, 1);
                  SpawnPos += new Vector2(0, 2f);
             } 
        }
        #region Level2
        if (Level == 2)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int ran = Random.Range(0, 100);
                if(ran <81)
                {
                    tagtospawn = "Clound";
                }
                if(ran <80 && ran >96 )
                {
                    tagtospawn = "MoveClound";
                }
                if(ran >95)
                {
                    tagtospawn = "FluffyClound";
                }
                else
                {
                    tagtospawn = "Clound";
                }
                objectPooler.SpawnFormPool(tagtospawn, new Vector2(Random.Range(-1.8f, 2.5f), SpawnPos.y), Quaternion.identity, 1);
                SpawnPos += new Vector2(0, 2f);
            }

        }
        #endregion

        #region Level3
        if (Level == 3)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int ran = Random.Range(1, 11);
                if (ran < 7)
                {
                    tagtospawn = "Clound";
                }
                if (ran > 7 && ran < 9)
                {
                    tagtospawn = "MoveClound";
                }
                if (ran == 10)
                {
                    tagtospawn = "FluffyClound";
                }

                objectPooler.SpawnFormPool(tagtospawn, new Vector2(Random.Range(-1.8f, 2.5f), SpawnPos.y), Quaternion.identity, 1);
                SpawnPos += new Vector2(0, 2f);
            }
        }
        #endregion

        #region Level4
        if (Level == 4)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int ran = Random.Range(0, 100);
                if (ran < 61) { tagtospawn = "Clound"; }
               
                if (ran > 60 && ran < 86) {  tagtospawn = "MoveClound"; }
               
                if (ran > 85 && ran < 96) { tagtospawn = "FluffyClound"; }
               
                if(ran > 95) { tagtospawn = "Pillar"; }

                objectPooler.SpawnFormPool(tagtospawn, new Vector2(Random.Range(-1.8f, 2.5f), SpawnPos.y), Quaternion.identity, 1);
                SpawnPos += new Vector2(0, 2f);
            }
        }
        #endregion

        #region Level5
        if (Level == 5)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int ran = Random.Range(0, 100);
                if (ran < 51) { tagtospawn = "Clound"; }

                if (ran > 50 && ran < 81) { tagtospawn = "MoveClound"; }

                if (ran > 80 && ran < 96) { tagtospawn = "FluffyClound"; }

                if (ran > 95) { tagtospawn = "Pillar"; }

                objectPooler.SpawnFormPool(tagtospawn, new Vector2(Random.Range(-1.8f, 2.5f), SpawnPos.y), Quaternion.identity, 1);
                SpawnPos += new Vector2(0, 3f);
            }
        }
        #endregion

        #region Level6
        if (Level == 6)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int ran = Random.Range(0, 100);
                if (ran < 36) { tagtospawn = "Clound"; }

                if (ran > 35 && ran < 76) { tagtospawn = "MoveClound"; }

                if (ran > 75 && ran < 91) { tagtospawn = "FluffyClound"; }

                if (ran > 90) { tagtospawn = "Pillar"; }

                objectPooler.SpawnFormPool(tagtospawn, new Vector2(Random.Range(-1.8f, 2.5f), SpawnPos.y), Quaternion.identity, 1);
                SpawnPos += new Vector2(0, 3f);
            }
        }
        #endregion

        #region Level7
        if (Level == 7)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int ran = Random.Range(0, 100);
                if (ran < 31) { tagtospawn = "Clound"; }

                if (ran > 30 && ran < 71) { tagtospawn = "MoveClound"; }

                if (ran > 70 && ran < 91) { tagtospawn = "FluffyClound"; }

                if (ran > 90) { tagtospawn = "Pillar"; }

                objectPooler.SpawnFormPool(tagtospawn, new Vector2(Random.Range(-1.8f, 2.5f), SpawnPos.y), Quaternion.identity, 1);
                SpawnPos += new Vector2(0, 3f);
            }
        }
        #endregion

        #region Level8
        if (Level == 8)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int ran = Random.Range(0, 100);
                if (ran < 21) { tagtospawn = "Clound"; }

                if (ran > 20 && ran < 66) { tagtospawn = "MoveClound"; }

                if (ran > 65 && ran < 86) { tagtospawn = "FluffyClound"; }

                if (ran > 85) { tagtospawn = "Pillar"; }

                objectPooler.SpawnFormPool(tagtospawn, new Vector2(Random.Range(-1.8f, 2.5f), SpawnPos.y), Quaternion.identity, 1);
                SpawnPos += new Vector2(0, 4f);
            }
        }
        #endregion

        #region Level9
        if (Level == 9)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int ran = Random.Range(0, 100);
                if (ran < 11) { tagtospawn = "Clound"; }

                if (ran > 10 && ran < 61) { tagtospawn = "MoveClound"; }

                if (ran > 60 && ran < 81) { tagtospawn = "FluffyClound"; }

                if (ran > 80) { tagtospawn = "Pillar"; }

                objectPooler.SpawnFormPool(tagtospawn, new Vector2(Random.Range(-1.8f, 2.5f), SpawnPos.y), Quaternion.identity, 1);
                SpawnPos += new Vector2(0, 4f);
            }
        }
        #endregion

        #region Level10
        if (Level == 10)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int ran = Random.Range(0, 100);
                if (ran < 6) { tagtospawn = "Clound"; }

                if (ran > 5 && ran < 56) { tagtospawn = "MoveClound"; }

                if (ran > 55 && ran < 76) { tagtospawn = "FluffyClound"; }

                if (ran > 75) { tagtospawn = "Pillar"; }

                objectPooler.SpawnFormPool(tagtospawn, new Vector2(Random.Range(-1.8f, 2.5f), SpawnPos.y), Quaternion.identity, 1);
                SpawnPos += new Vector2(0, 4f);
            }
        }
        #endregion

    }

    #region Level
    void UpdateLevel()
    {
        if(currentscore >= 1050)
        {
            Level = 2;
        }
        if (currentscore >= 2100)
        {
            Level =3;
        }
        if (currentscore >= 3150)
        {
            Level = 4;
        }
        if (currentscore >= 4200)
        {
            Level = 5;
        }
        if (currentscore >= 5250)
        {
            Level = 6;
        }
        if (currentscore >= 6300)
        {
            Level = 7;
        }
        if (currentscore >= 7350)
        {
            Level = 8;
        }
        if (currentscore >= 8400)
        {
            Level = 9;
        }
        if (currentscore >= 9450)
        {
            Level = 10;
        }
    }
    #endregion Level


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OBJPointtospawn"))
        {
            SpawnClound();
            ObjPointtospawn.gameObject.transform.position += new Vector3(0, 20);
        }
    }

}
