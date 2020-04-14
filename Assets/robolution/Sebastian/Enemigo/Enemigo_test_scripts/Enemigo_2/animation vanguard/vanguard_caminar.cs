using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanguard_caminar : MonoBehaviour
{
    public Transform jugador;
    UnityEngine.AI.NavMeshAgent Enemigo;
    private bool dentro = false;
    public float distanciaMin;
    public Transform puntoA;
    public Transform puntoB;
    private bool ir = false;

    public bool mirar = false;

    Animator animacion;

    public GameObject enemy;
    bool estaAtacando = false;
    public float tiempo = 0;
    public float tiempoAtaque = 0;
    public float duracionAtaque = 1.0f;
    public int ataqueDamage = 10;
    VidaPlayer enemigoVida;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        Enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }


    private void OnTriggerEnter(Collider col) {
        if(col.gameObject == enemy){
            estaAtacando = true;
            //enemigoVida = enemy.GetComponent<VidaPlayer>();
        }

    }

    private void OnTriggerExit(Collider col) {
        if(col.gameObject == enemy){
            estaAtacando = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        tiempoAtaque += Time.deltaTime;

        //bool run = true;
        //animacion.SetBool("running",run);
        
        float dist = distanciaMin+1;

        if(jugador != null){
        dist = Vector3.Distance(transform.position,jugador.position);
        tiempo += Time.deltaTime;
        /**if(tiempo >= duracionAtaque && estaAtacando){
            Atack();
        }**/

        if(tiempo >= duracionAtaque && dist<2.6f){
            //run = false;
            //animacion.SetBool("running",run);
            animacion.SetTrigger("atacar");
            Atack();
            Enemigo.destination = this.transform.position;
        }

        if(!dentro & (dist <= distanciaMin) && (dist >= 2.6f)){
            
            /**if(!dentro & (dist <= distanciaMin)){
            Enemigo.destination = this.transform.position;

            if(mirar == true){
                transform.LookAt(jugador);
                }
            }
            else{
                Enemigo.destination = jugador.position;
            }**/
            Enemigo.destination = jugador.position;   
        }
        }else{
            dist = distanciaMin+1;
        }
        if(dentro & (dist > distanciaMin)){
            Enemigo.destination = this.transform.position;
        }
        if(!dentro & (dist > distanciaMin)){
            
            if(Vector3.Distance(transform.position,puntoA.position) <= 2.1f){
                ir = true;
            }
            if(Vector3.Distance(transform.position,puntoB.position) <= 2.1f){
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


    void Atack(){
        tiempo = 0f;
        //VidaPlayer enemigoVida = collider.GetComponent<VidaPlayer>()
        //Debug.Log("atake");
        VidaPlayer enemigoVida = enemy.GetComponent<VidaPlayer>();
        if( enemigoVida != null){
             Debug.Log("atake");
            enemigoVida.RecibirDamaged(10);
        }
    }
}
