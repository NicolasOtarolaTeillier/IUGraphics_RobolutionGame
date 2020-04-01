using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//funciona
public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 5f; // velocidad de 3,5 metros por segundo
    private float _speedRun = 10f;

    private readonly float _gravity = -9.81f; // gravedad de la tierra

    [SerializeField] // para poder importar el objeto muzzzleflashefect al player
    private GameObject _muzzleFlashEfect;

    [SerializeField] // para poder importar el objeto muzzzleflashefect al player
    private GameObject _cartridgeEjectEffect;

    [SerializeField] // para poder importar el objeto muzzzleflashefect al player
    private GameObject _bulletImpactMetalEffect;

    [SerializeField]
    private GameObject _Heavy;

    [SerializeField]
    private GameObject _Ak47;


    [SerializeField]
    private AudioSource _Ak47Audio;

    [SerializeField]
    public float _fireRate = 0.1F;
    private float _nextFire = 0.0F;

    [SerializeField]
    private int _currentAmmo;
    private int _maxArmo = 50;
    private bool _isReloading = false;


    [SerializeField]
    public bool _weaponHeavy = false;
    public bool _weaponAk47 = true;

    private bool _changeWeapon = false  ;

    private UIManager _uiManager;

    public Text textoAmmo;
    public Text noAmmo;

    public int fullAmmo = 150;
    

    void Start()
    {        
        _controller = GetComponent<CharacterController>(); // nos permite acceder a sus metodos para mover al personaje con move()
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _currentAmmo = 30;
        noAmmo.enabled = false;
        _uiManager = GameObject.Find("Canvas_Fondo").GetComponent<UIManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _weaponHeavy == true)
        {
           changeWeapon();
        }



        if (Input.GetMouseButton(0) && _currentAmmo > 0)
        {
            shoot();
        }
        else
        {
            _muzzleFlashEfect.SetActive(false);
            _cartridgeEjectEffect.SetActive(false);
            //_Ak47Audio.Stop();
            //Debug.Log("RayCast no golpeo nada");
        }

        if (Input.GetKeyDown(KeyCode.R)&& _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
            
        }


        if (Input.GetKeyDown(KeyCode.Escape)) //ocultar el mouse de la vista
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }
        CalculateMovement(); // calcular las fisicas del objeto Player, mediante el componente CharacterController

    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //teclas ws
        float verticalInput = Input.GetAxis("Vertical"); //teclas ad
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity;
        if (Input.GetKey(KeyCode.LeftShift)){ //correr
            velocity = direction * _speedRun;
        }
        else
        {
            velocity = direction * _speed; //agregamos velocidad a la direcion del movimiento

        }
        velocity.y = _gravity;  //agregamos gravedad en el eje y
        velocity = transform.transform.TransformDirection(velocity);// de direciones locales a direcciones del mundo
        _controller.Move(velocity * Time.deltaTime); //velocidad de movimiento
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
                _Ak47Audio.Stop();
                if (_Ak47Audio.isPlaying == false)
                {
                    _Ak47Audio.Play();
                }
                _muzzleFlashEfect.SetActive(true);
                _cartridgeEjectEffect.SetActive(true);
                Instantiate(_bulletImpactMetalEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                _currentAmmo--;
                _uiManager.UpdateAmmo(_currentAmmo, fullAmmo);
                
            }
            //Debug.Log("RayCast golpeo algo" + hitInfo.transform.name);
            
        }
    }
    void changeWeapon() {
        _Ak47.SetActive(_changeWeapon);
        _Heavy.SetActive(!_changeWeapon);
        if (_changeWeapon == true)
        {
            _changeWeapon = false;
        }
        else
        {
            _changeWeapon = true;
        }
        //Debug.Log("cambio de arma");
    }
    IEnumerator Reload()
    {
        if(fullAmmo > 0)
        {
            yield return new WaitForSeconds(1.5f);
            if(30 - _currentAmmo > fullAmmo)
            {
                _currentAmmo = _currentAmmo + fullAmmo;
                fullAmmo = 0;
            }
            else
            {
                fullAmmo = fullAmmo - 30 + _currentAmmo;
                _currentAmmo = 30;
            }
            
            _isReloading = false;
            _uiManager.UpdateAmmo(_currentAmmo, fullAmmo);
        }
        else
        {
            noAmmo.enabled = true;          
            yield return new WaitForSeconds(1.0f);
            noAmmo.enabled = false;
            _isReloading = false;
        }
        
    }

}

