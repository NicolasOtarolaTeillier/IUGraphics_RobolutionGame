﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEnemy : MonoBehaviour
{
    
    public float distancia = 100f;
    int capaEnemigo;
    Ray lineaDisparo;
    RaycastHit golpeDisparo;
    LineRenderer rayo;
    AudioSource audio;

    public GameObject effect;
    public GameObject efeDisparo;
    public float force = 10;
    float timeRay = 1.0f; 
    float tiempo;
    bool modoAtaque = false;
    void Start()
    {
        //rayo = GetComponent<LineRenderer>();
        Debug.Log("hola mundo");
        tiempo = 0;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        tiempo += Time.deltaTime;
        lineaDisparo.origin = transform.position;
        lineaDisparo.direction = transform.forward;
        //rayo.SetPosition(0,transform.position);
        if(Physics.Raycast(lineaDisparo.origin, lineaDisparo.direction, out golpeDisparo, distancia) && (modoAtaque == true) &&  tiempo > timeRay ){


            /**if(golpeDisparo.collider){
                rayo.SetPosition(1,golpeDisparo.point);
            }**/

            if(audio.isPlaying==false){
                    audio.Play();
                }
            efeDisparo.SetActive(true);
            VidaPlayer enemigoVida = golpeDisparo.collider.GetComponent<VidaPlayer>();

            if(enemigoVida != null && tiempo > timeRay){
                tiempo = 0;
                GameObject _efectt = Instantiate(effect , golpeDisparo.point, Quaternion.identity);
                Destroy(_efectt, 0.2f);
                enemigoVida.RecibirDamaged(10);
                Debug.Log("disparando... player");
            }

            if(golpeDisparo.collider.GetComponent<Rigidbody>() != null){
                golpeDisparo.collider.GetComponent<Rigidbody>().AddForce(golpeDisparo.normal * force * -1.0f);
            }

        }else{
            audio.Stop();
            efeDisparo.SetActive(false);
        }
    }
    void OnDrawGizmos() {

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(lineaDisparo.origin,lineaDisparo.direction *distancia);    
    }    

    public void ModoAtaque(){
        Debug.Log("modo ataque activado");
        modoAtaque = true;
    }

    public void ModoAtaqueOff(){
        Debug.Log("modo ataque activado");
        modoAtaque = false;
    }
}
