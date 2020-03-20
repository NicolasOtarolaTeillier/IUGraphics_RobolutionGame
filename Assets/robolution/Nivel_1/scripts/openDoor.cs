
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class openDoor : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;
    private bool _isEnter = false;

    [SerializeField]
    private GameObject _door_1_left; 

    [SerializeField]
    private GameObject _door_1_right;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isEnter = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isEnter = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _isEnter = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                Player Sofronov = other.GetComponent<Player>();
                if (Sofronov != null)
                {
                    if (!_isOpen) // si la puerta esta cerrada, abrirla
                    {
                        _isOpen = true;
                        _door_1_left.SetActive(false);
                        _door_1_right.SetActive(false);

                        Debug.Log("puerta abierta");
                    }
                    else
                    {
                        _isOpen = false;
                        _door_1_left.SetActive(true);
                        _door_1_right.SetActive(true);
                        Debug.Log("puerta cerrada");
                    }
                }
            }
        }
    }


    private void OnGUI()
    {
        if (_isEnter)
        {
             GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
        }
    }
}