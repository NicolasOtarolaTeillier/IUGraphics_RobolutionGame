using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tablero : MonoBehaviour
{
    private bool done = false;
    private bool isEnter = false;
    public GameObject trigg;
    public GameObject puerta;
    public Light secLight;
    public Text desbq;
    AudioSource alarm;

    // Start is called before the first frame update
    void Start()
    {
        alarm = GetComponent<AudioSource>();
        alarm.volume = 0.6f;
        trigg.SetActive(false);
        puerta.SetActive(true);
        secLight.color = Color.green;
        desbq.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isEnter = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isEnter = false;
            desbq.enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !done)
        {
            desbq.enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                secLight.color = Color.red;
                alarm.Play();
                puerta.SetActive(false);
                trigg.SetActive(true);
                done = true;
            }
        }
    }
    
}
