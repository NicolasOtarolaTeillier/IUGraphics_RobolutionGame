using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_enemy : MonoBehaviour
{
    
    public float distancia = 100f;
    int capaEnemigo;
    Ray lineaDisparo;
    RaycastHit golpeDisparo;

    public GameObject effect;
    public float force = 10;
    float timeRay = 1.0f; 
    float tiempo;
    bool modoAtaque = false;
    void Start()
    {
        Debug.Log("hola mundo");
        tiempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        lineaDisparo.origin = transform.position;
        lineaDisparo.direction = transform.forward;

        if(Physics.Raycast(lineaDisparo.origin, lineaDisparo.direction, out golpeDisparo, distancia) && modoAtaque){
            
            

            VidaPlayer enemigoVida = golpeDisparo.collider.GetComponent<VidaPlayer>();

            if(enemigoVida != null && tiempo > timeRay){
                tiempo = 0;
                GameObject _efectt = Instantiate(effect , golpeDisparo.point, Quaternion.identity);
                Destroy(_efectt, 0.2f);
                enemigoVida.RecibirDamaged(10);
                //Debug.Log("disparando... player");
            }

            if(golpeDisparo.collider.GetComponent<Rigidbody>() != null){
                golpeDisparo.collider.GetComponent<Rigidbody>().AddForce(golpeDisparo.normal * force * -1.0f);
            }

        }
    }
    private void OnDrawGizmos() {

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(lineaDisparo.origin,lineaDisparo.direction *distancia);    
    }    

    public void ModoAtaque(){
        modoAtaque = true;
    }

    public void ModoAtaqueOff(){
        modoAtaque = false;
    }
}
