using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_enemiga : MonoBehaviour
{
    public GameObject Target;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    public float distance;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Target.transform.position, transform.position) < distance)
        {
            agent.SetDestination(Target.transform.position);
            agent.speed = 3;
        }
        else
        {
            agent.speed = 0;
        }   
    }
}
