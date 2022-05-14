using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject MAP;
    float pointtospawn;
    Vector2 positiontospawn = Vector2.zero;

    Queue<GameObject> Mapque;
    private void Awake()
    {
        Mapque = new Queue<GameObject>();
    }

    void Update()
    {
        if(this.transform.position.y >= pointtospawn)
        {
            GameObject map = Instantiate(MAP);
            Mapque.Enqueue(map);
            pointtospawn += 100; 
            map.transform.position = positiontospawn;
            positiontospawn += new Vector2(0, 120);

            if(Mapque.Count > 3)
            {
                GameObject oldmap = Mapque.Dequeue();
                Destroy(oldmap);
            }
        }
    }
}
