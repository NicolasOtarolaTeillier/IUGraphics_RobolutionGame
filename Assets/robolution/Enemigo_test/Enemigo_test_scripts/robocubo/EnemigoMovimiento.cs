using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
     public Transform jugador;
    UnityEngine.AI.NavMeshAgent Enemigo;
    private bool dentro = false;
    public float distanciaMin;
    public Transform puntoA;
    public Transform puntoB;
    private bool ir = false;

    public bool mirar = false;
    //public GameObject modoAtack;
    public RayEnemy modoAtaque;

    // Start is called before the first frame update
    void Start()
    {
        Enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //modoAtaque = modoAtack.GetComponent<RayEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float dist;
        if(jugador != null){
        dist = Vector3.Distance(transform.position,jugador.position);
        if(!dentro & (dist <= distanciaMin)){

           

            if(!dentro & (dist <= distanciaMin-5)){
            Enemigo.destination = this.transform.position;

                if(mirar == true){
                    transform.LookAt(jugador);
                }
            }
            else{
                Enemigo.destination = jugador.position;
            } 
             modoAtaque.ModoAtaque();  
        }
        }else{
            dist = distanciaMin+1;
            modoAtaque.ModoAtaqueOff();
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
