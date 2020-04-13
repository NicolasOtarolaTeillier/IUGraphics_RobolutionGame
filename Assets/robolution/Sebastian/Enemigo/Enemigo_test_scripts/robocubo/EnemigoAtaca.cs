using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAtaca : MonoBehaviour
{
    public int ataqueDamage = 20;
    public float tiempoDisparo = 0.15f;
    public float distancia = 100f;

    float tiempo;
    Ray lineaDisparo;
    RaycastHit golpeDisparo;
    int capaEnemigo;
    //ParticleSystem particulaDisparo;
    //LineRenderer efectoDisparo;
    //AudioSource sonidoDisparo;
    //Light iluminacionDisparo;
    float tiempoEfecto = 0.2f;

    public bool atack = false;

    void Awake()
    {
        capaEnemigo = LayerMask.GetMask("Shootable");
        //efectoDisparo = GetComponent<LineRenderer>();
        //sonidoDisparo = GetComponent<AudioSource>();
        //iluminacionDisparo = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        /**if(Input.GetButton("fire1_") && tiempo >=tiempoDisparo){

            Disparo();
        }**/

        if(atack == true && tiempo >=tiempoDisparo){

            Disparo();
        }
        if(tiempo >= tiempoDisparo*tiempoEfecto){
            EfectoDisparo();
        }
    }

    void Disparo()
    {
        tiempo = 0f;
        //sonidoDisparo.Play();
        //iluminacionDisparo.enabled = true;

        //particulaDisparo.Stop();
        //particulaDisparo.Play();

        //efectoDisparo.enabled = true;
        //efectoDisparo.SetPosition(0,transform.position);

        lineaDisparo.origin = transform.position;
        lineaDisparo.direction = transform.forward;

        if(Physics.Raycast(lineaDisparo, out golpeDisparo, distancia, capaEnemigo) ){
            //EnemigoVida enemigoVida = golpeDisparo.collider.GetComponent<EnemigoVida>();
            VidaPlayer enemigoVida = golpeDisparo.collider.GetComponent<VidaPlayer>();

            if(enemigoVida != null){
                enemigoVida.RecibirDamaged(ataqueDamage);
                Debug.Log("disparando...");
            }

            //efectoDisparo.SetPosition(1, golpeDisparo.point);
        }
        /**else
        {
            //efectoDisparo.SetPosition(1, lineaDisparo.origin + lineaDisparo.direction * distancia);

        }**/

    }

    void EfectoDisparo(){
        //iluminacionDisparo.enabled = false;
        //efectoDisparo.enabled = false;
    }
}
