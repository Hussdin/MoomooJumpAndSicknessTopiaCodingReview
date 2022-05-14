using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientNavmeshController : MonoBehaviour
{
    public NavMeshAgent agent;
    void Update()
    {
        
    }

    public void changePos(GameObject pos)
    {
        agent.SetDestination(pos.transform.position);
    }
}
