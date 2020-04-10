using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    
    public int estableserVida = 100;
    public int obtenerVida;
    //public slider barraVida;
    //public Imagen efectoDamage;
    //public AudioClip sonidoDamage;
    //public float velodidadDamage = 5f;
    // public color colorFlash = new color(1f,0f,0f,0.1f)

    //Animator animaciones;
    //AudioSource sonidoJugador;
    //Jugador jugadorMovimiento;
    EnemigoMovimiento enemigoMovimiento;

    bool estaMuerto;
    bool damaged;

    //Estableser valores antes que inicie el juego
    void Awake(){
        //animaciones = GetComponent<Animator>();
        //sonidoJugador = GetComponent<AudioSource>();
        //jugadorMovimiento = GetComponent<Jugador>();

        obtenerVida = estableserVida;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /**if(damaged)
        {
            efectoDamage.color = colorFlash;
        }else
        {
            efectoDamage.color = Color.Lerp(efectoDamage.color,Color.clear,velocidadFlash * Time.deltaTime);
        }

        damaged = false;**/

    }

    public void RecibirDamaged(int cantidad)
    {
        Debug.Log("me dispara!!");
        damaged = true;
        obtenerVida -= cantidad;
        //barraVida.value = obtenerVida;
        //sonidoJUgador.Play();

        if(obtenerVida <= 0 ){
            Muerto();
        }

    }

    void Muerto(){
        estaMuerto =true;
        //animaciones.SetTrigger("muerte");
        //sonidoJugador.clip =sonidoDamage;
        //sonidoJugador.Play();
        //JugadorMovimiento.enabled = false;
        //enemigoMovimiento.enabled = false;
        Debug.Log("estoy muerto");
    }

}
