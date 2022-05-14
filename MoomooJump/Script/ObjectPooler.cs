using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool 
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    GameObject objecttospawn = null;
    public static ObjectPooler Instance;

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();


        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i =0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFormPool (string tag, Vector2 position, Quaternion rotation,int count)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null ;
        }
        for (int s = 0; s < count; s++)
        {
            objecttospawn = poolDictionary[tag].Dequeue();
            objecttospawn.transform.position = position;
            objecttospawn.transform.rotation = rotation;
            objecttospawn.SetActive(true);
        }
        return objecttospawn;
    } 

    public GameObject Getbacktopool(string tag,GameObject obj)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        obj.SetActive(false);
        return obj;
    }

    public GameObject Addqueue(string tag,GameObject Gameobj)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        poolDictionary[tag].Enqueue(Gameobj);
        return gameObject;
    }
}
