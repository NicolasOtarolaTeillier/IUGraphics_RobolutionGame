using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apuntar : MonoBehaviour
{
    public Transform player;
    public Transform front;
    public float disMin = 10;
    void Start()
    {
        
    }
    void Update()
    {
        float dist = Vector3.Distance(transform.position,player.position);
        if(dist <= disMin){
            transform.LookAt(player);
        }
        else
        {

            transform.LookAt(front);
        }
        

    }
}
