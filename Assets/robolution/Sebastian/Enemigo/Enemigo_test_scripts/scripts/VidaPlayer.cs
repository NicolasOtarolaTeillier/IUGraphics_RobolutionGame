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


    public GameObject partes;

    bool estaMuerto;
    bool damaged;

    public bool isEnemy = false;
    public bool isRobot = false;
    public bool isCyborg = false;

    [SerializeField]
    private GameObject exp_1;

    [SerializeField]
    private GameObject exp_2;
    Animator animacion;
    public AudioSource audioExplosion;
    

    public bool isPlayer = false;

    //Estableser valores antes que inicie el juego
    void Awake(){
        //animaciones = GetComponent<Animator>();
        //sonidoJugador = GetComponent<AudioSource>();
        //jugadorMovimiento = GetComponent<Jugador>();
        animacion = GetComponent<Animator>();
        estaMuerto = false;
        obtenerVida = estableserVida;
    }

    void Start()
    {
        exp_1.SetActive(false);
        exp_2.SetActive(false);
        audioExplosion.Stop();

        //exp_1.enabled = false;
        //exp_2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        
        //exp_1.Stop();
        //exp_2.Stop();
        /**if(estaMuerto == false){
            exp_1.Stop();
            exp_2.Stop();  
        }**/

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

        if(animacion != null){
            animacion.SetTrigger("daño");
        }
        damaged = true;
        obtenerVida -= cantidad;
        //barraVida.value = obtenerVida;
        //sonidoJUgador.Play();
        //audioExplosion.Play();
        if(obtenerVida <= 0 ){
            Muerto();
        }

    }

    void Muerto(){
        estaMuerto =true;
        if(animacion != null){
            animacion.SetBool("morir",true);
        }
        //animaciones.SetTrigger("muerte");
        //sonidoJugador.clip =sonidoDamage;
        //sonidoJugador.Play();
        //JugadorMovimiento.enabled = false;
        //enemigoMovimiento.enabled = false;
        //Debug.Log("estoy muerto");
        if (isRobot == true){
            Explode();
        }

    }

     void Explode() {
            //exp_1.enabled = true;
            //exp_2.enabled = true;
            if(audioExplosion.isPlaying == false){
                audioExplosion.Play();
            }
            exp_1.SetActive(true);
            exp_2.SetActive(true);
            //exp_2.SetActive(true);
            //exp_1.Play();
            if(isCyborg == false){
                MeshRenderer mesh = GetComponent<MeshRenderer>();
                BoxCollider  col = GetComponent<BoxCollider>();
                //sonidoJugador = GetComponent<MeshRenderer>();
                mesh.enabled = false;
                col.enabled = false;
            }
            if(isPlayer == false){
            Destroy(partes,0.1f);
            Destroy(gameObject,2.0f);
            }
            
        }

        public int GetLife(){
            return obtenerVida;
        }

}
