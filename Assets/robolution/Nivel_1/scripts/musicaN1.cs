using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaN1 : MonoBehaviour
{
    AudioSource musica;
    public GameObject puerta;
    public bool paso = false;

    // Start is called before the first frame update
    void Start()
    {
        musica = GetComponent<AudioSource>();
             
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
               paso = true; 
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (paso)
        {
            if(!musica.isPlaying)
                {
                    musica.Play();
                }
        }
    }
}
