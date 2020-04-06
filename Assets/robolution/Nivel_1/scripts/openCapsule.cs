using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCapsule : MonoBehaviour
{
    public GameObject cap1;
    public GameObject cap2;
    
    AudioSource openSound;
    private bool paso = false;
    private bool unaVez = true;
    public float timeI;
    public float timeF;
  
    void Start() 
    {
        openSound = GetComponent<AudioSource>();
        openSound.pitch = 0.4f;
        openSound.volume = 0.8f;
    }
    void Update()
    {
        timeF = Time.time;
        if(paso)
        {
            if(!openSound.isPlaying && unaVez)
            {
                openSound.Play();
                unaVez = false;
            }
            cap1.transform.position += transform.up * Time.deltaTime;
            cap2.transform.position += transform.up * Time.deltaTime;
            if(timeF - timeI > 4.0f)
            {
                cap1.SetActive(false);
                cap2.SetActive(false);
            }
        }
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            paso = true;
            Debug.Log("sd");
        }
        timeI = Time.time;
        
    }
    
}

