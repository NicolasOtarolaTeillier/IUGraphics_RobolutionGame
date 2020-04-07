using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockedDoor : MonoBehaviour
{
    private bool isEnter = false;
    public Text unlock;

    void Start()
    {
        unlock.enabled = false;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isEnter = true;
            unlock.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isEnter = false;
            unlock.enabled = false;
        }
    }
    private void OnGUI()
    {
        if (isEnter)
        {
             GUI.Label(new Rect(new Rect(Screen.width / 2 - 45, Screen.height - 100, 150, 30)), "Puerta cerrada");
             

        }
    }
}
