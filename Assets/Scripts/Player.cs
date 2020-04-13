using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//funciona
public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 3.5f; // velocidad de 3,5 metros por segundo

    private readonly float _gravity = -9.81f; // gravedad de la tierra

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
    void Start()
    {
        _controller = GetComponent<CharacterController>(); // nos permite acceder a sus metodos para mover al personaje con move()
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _currentAmmo = _maxArmo;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    void Update()
    {


<<<<<<< Updated upstream:Assets/Scripts/Player.cs
        if (Input.GetMouseButton(0) && _currentAmmo > 0)
        {
            shoot();
        }
        else
        {
            _muzzleFlashEfect.SetActive(false);
            _cartridgeEjectEffect.SetActive(false);
            //_weaponAudio.Stop();
            Debug.Log("RayCast no golpeo nada");
        }

=======
       
>>>>>>> Stashed changes:Assets/robolution/Fps/scripts/Player.cs
        if (Input.GetKeyDown(KeyCode.R)&& _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
            
        }


      
        CalculateMovement(); // calcular las fisicas del objeto Player, mediante el componente CharacterController

    }
    void FixedUpdate(){
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

    }
    
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //teclas ws
        float verticalInput = Input.GetAxis("Vertical"); //teclas ad
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed; //agregamos velocidad a la direcion del movimiento
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
                _weaponAudio.Stop();
                if (_weaponAudio.isPlaying == false)
                {
                    _weaponAudio.Play();
                }
                _muzzleFlashEfect.SetActive(true);
                _cartridgeEjectEffect.SetActive(true);
                Instantiate(_bulletImpactMetalEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                _currentAmmo--;
                _uiManager.UpdateAmmo(_currentAmmo);
                
            }
            Debug.Log("RayCast golpeo algo" + hitInfo.transform.name);
            
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxArmo;
        _isReloading = false;
        _uiManager.UpdateAmmo(_currentAmmo);
    }

}

