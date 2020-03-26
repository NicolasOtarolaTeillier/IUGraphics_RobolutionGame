using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public Transform jugador;
    UnityEngine.AI.NavMeshAgent Enemigo;
    private bool dentro = false;
    public float distanciaMin;
    public Transform puntoA;
    public Transform puntoB;
    private bool ir = false;

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
        float dist = Vector3.Distance(transform.position,jugador.position);
        if(!dentro & (dist <= distanciaMin)){
            Enemigo.destination = jugador.position;
        }
        if(dentro & (dist > distanciaMin)){
            Enemigo.destination = this.transform.position;
        }
        if(!dentro & (dist > distanciaMin)){
            
            if(Vector3.Distance(transform.position,puntoA.position) <= 1.1f){
                ir = true;
            }
            if(Vector3.Distance(transform.position,puntoB.position) <= 1.1f){
                ir = false;
            }
            if(ir == false){
                Enemigo.destination = puntoA.position;
            }
            else{
                Enemigo.destination = puntoB.position;
            }
        }
    }
}
