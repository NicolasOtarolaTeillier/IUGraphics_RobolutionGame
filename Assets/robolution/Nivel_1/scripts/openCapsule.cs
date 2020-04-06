using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCapsule : MonoBehaviour
{
    public GameObject rightW;
    public GameObject leftW;
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
            rightW.transform.position += transform.up * Time.deltaTime;
            leftW.transform.position += transform.up * Time.deltaTime;
            if(timeF - timeI > 4.0f)
            {
                rightW.SetActive(false);
                leftW.SetActive(false);
            }
        }
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rightW.transform.position += transform.up * Time.deltaTime;
            leftW.transform.Translate(Vector3.forward * Time.deltaTime);
            Debug.Log("gachiBASS");
            paso = true;
        }
        timeI = Time.time;
        
    }
    
}

