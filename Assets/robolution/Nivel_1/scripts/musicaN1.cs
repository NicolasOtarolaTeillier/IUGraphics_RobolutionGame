using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaN1 : MonoBehaviour
{
    AudioSource musica;
    private bool paso = true;

    // Start is called before the first frame update
    void Start()
    {
        musica = GetComponent<AudioSource>();
        musica.volume = 0.6f;
             
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
          if(!musica.isPlaying && paso)
            {
                musica.Play();
                paso = false;
            }
        }
    }


    
}
