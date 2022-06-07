using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMovement : MonoBehaviour
{
    public Transform goal;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(goal.position);
    }
}
