using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mole : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 1000;
    }

    void Update()
    {
        
    }

    public void SetDestination(Transform t)
    {
        agent.destination = t.position;
    }
}
