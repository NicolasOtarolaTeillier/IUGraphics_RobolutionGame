using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runElevator : MonoBehaviour
{
    
    private bool _isEnter = false;
    
    public GameObject door_1_left; 
    public GameObject door_1_right;

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
        //Debug.Log("dentro");
        if (other.tag == "Player")
        {
            //_isEnter = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("gachiBASS");
                door_1_left.SetActive(true);
                door_1_right.SetActive(true);
            }
        }
    }


    private void OnGUI()
    {
        if (_isEnter)
        {
             GUI.Label(new Rect(Screen.width / 2 - 110, Screen.height - 100, 210, 30), "Presiona 'F' para activar el ascensor");
        }
    }
}