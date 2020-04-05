using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : MonoBehaviour
{
   
    CharacterController player;
    AudioSource walk;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        walk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.velocity.magnitude > 0.0f && player.velocity.magnitude < 4.0f)
        {
            if(!walk.isPlaying)
            {
                walk.volume = Random.Range(0.15f,0.22f);
                walk.pitch = Random.Range(0.7f,0.8f);
                walk.Play();           
            }       
        }
        else if(player.velocity.magnitude > 4.0f)
        {
           if(!walk.isPlaying)
            {
                walk.volume = Random.Range(0.15f,0.22f);
                walk.pitch = Random.Range(1.4f,1.8f);
                walk.Play();           
            }       
        }
        else
        {
            walk.Stop();           
        }
    }
    

}