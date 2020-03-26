using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public Transform jugador;
    UnityEngine.AI.NavMeshAgent Enemigo;
    private bool dentro = false;

    void Start()
    {
        Enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            dentro = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            dentro = false;
        }
    }


    void Update()
    {
        if(!dentro){
            Enemigo.destination = jugador.position;
        }
        if(dentro){
            Enemigo.destination = this.transform.position;
        }
    }
}
