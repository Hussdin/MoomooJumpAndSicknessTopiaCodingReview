using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueSystem : MonoBehaviour
{
    public static QueSystem Qsystem;
    Queue<GameObject> Spawnpoint = new Queue<GameObject>();
    Queue<GameObject> SpecialSpawnpoint = new Queue<GameObject>();

    [SerializeField]
    GameObject sp1, sp2, sp3, sp4, sp5, sp6, sp7, sp8;

    [SerializeField]
    GameObject ssp1, ssp2, ssp3, ssp4;
    private void Awake()
    {
        Qsystem = this;
        setfirstque();
        setfirstSpecialque();
    }
    void setfirstque()
    {
        Spawnpoint.Enqueue(sp1);
        Spawnpoint.Enqueue(sp2);
        Spawnpoint.Enqueue(sp3);
        Spawnpoint.Enqueue(sp4);
        Spawnpoint.Enqueue(sp5);
        Spawnpoint.Enqueue(sp6);
        Spawnpoint.Enqueue(sp7);
        Spawnpoint.Enqueue(sp8);
    }
    public GameObject DQ()
    {
        GameObject Gobject =   Spawnpoint.Dequeue();
        return Gobject;
    }
    public void NQ(GameObject gameobject)
    {
        Spawnpoint.Enqueue(gameobject);
    }

    void setfirstSpecialque()
    {
        SpecialSpawnpoint.Enqueue(ssp1);
        SpecialSpawnpoint.Enqueue(ssp2);
        SpecialSpawnpoint.Enqueue(ssp3);
        SpecialSpawnpoint.Enqueue(ssp4);

    }
    public GameObject DQS()
    {
        GameObject Gobject = SpecialSpawnpoint.Dequeue();
        return Gobject;
    }
    public void NQS(GameObject gameobject)
    {
        SpecialSpawnpoint.Enqueue(gameobject);
    }
}
