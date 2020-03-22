using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private bool _isEnter = false;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player Sofronov = other.GetComponent<Player>();
                if (Sofronov != null && Sofronov._weaponHeavy == false)
                {
                    Sofronov._weaponHeavy = true;
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private void OnGUI()
    {
        if (_isEnter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 40), "Press 'E' to take the weapon");
        }
    }
}