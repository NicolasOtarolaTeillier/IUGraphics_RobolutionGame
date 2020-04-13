using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{

     [SerializeField] // para poder importar el objeto muzzzleflashefect al player
    private GameObject _muzzleFlashEfect;

    [SerializeField] // para poder importar el objeto muzzzleflashefect al player
    private GameObject _cartridgeEjectEffect;

    [SerializeField] // para poder importar el objeto muzzzleflashefect al player
    private GameObject _bulletImpactMetalEffect;

    [SerializeField]
    private AudioSource _weaponAudio;

     [SerializeField]
    public float _fireRate = 0.1F;
    private float _nextFire = 0.0F;

    [SerializeField]
    private int _currentAmmo;
    private int _maxArmo = 50;
    private bool _isReloading = false;

    private UIManager _uiManager;


    public Transform jugador;
    UnityEngine.AI.NavMeshAgent Enemigo;
    private bool dentro = false;
    public float distanciaMin;
    public Transform puntoA;
    public Transform puntoB;
    private bool ir = false;

    private Camera camara_enemy;

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
            shoot();
            if(!dentro & (dist <= distanciaMin-5)){
            Enemigo.destination = this.transform.position;
            transform.LookAt(jugador);
            }
            else{
                Enemigo.destination = jugador.position;
            }
            
        }else{
            noshoot();
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

        void shoot()
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // setiamos el vector origen hacia donde apunta el rayo
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo)) //rayOrigin, out hitInfo
        {
            if (Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                _weaponAudio.Stop();
                if (_weaponAudio.isPlaying == false)
                {
                    _weaponAudio.Play();
                }
                _muzzleFlashEfect.SetActive(true);
                _cartridgeEjectEffect.SetActive(true);
                Instantiate(_bulletImpactMetalEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                _currentAmmo--;
               // _uiManager.UpdateAmmo(_currentAmmo);
                
            }
            Debug.Log("RayCast golpeo :" + hitInfo.transform.name);
            
            
        }
    }

    void noshoot(){
        _muzzleFlashEfect.SetActive(false);
        _cartridgeEjectEffect.SetActive(false);
    }

}
