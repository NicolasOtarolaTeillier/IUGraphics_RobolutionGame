using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player Sofronov = other.GetComponent<Player>();
                if (Sofronov != null)
                {
                    Sofronov._weaponHeavy = true;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}