using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoApunta : MonoBehaviour
{
    public Transform player;
    public Transform front;
    public float disMin = 10;
    public EnemigoAtaca ataque;

    void Awake()
    {
        ataque = GetComponent<EnemigoAtaca>();   
        ataque.atack = false;
    }
    void Update()
    {
        float dist = Vector3.Distance(transform.position,player.position);
        if(dist <= disMin){
            ataque.atack = true;
            transform.LookAt(player);
        }
        else
        {
            ataque.atack = false;
            transform.LookAt(front);
        }
        

    }
}
