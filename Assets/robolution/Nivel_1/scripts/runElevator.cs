using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class runElevator : MonoBehaviour
{
    
    private bool _isEnter = false;
    
    public GameObject door_1_left; 
    public GameObject door_1_right;
    AudioSource elevatorSound;
    private bool unaVez = true;
    public Image winBG;
    public Color color;

    void Start()
    {
        elevatorSound = GetComponent<AudioSource>();
        winBG.enabled = true;
        color = winBG.color;
    }
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
                if(!elevatorSound.isPlaying && unaVez)
                {
                    elevatorSound.Play();
                    StartCoroutine(Fade());
                    unaVez = false;
                }
                door_1_left.SetActive(true);
                door_1_right.SetActive(true);
            }
        }
    }


    private void OnGUI()
    {
        if (_isEnter && unaVez)
        {
             GUI.Label(new Rect(Screen.width / 2 - 110, Screen.height - 100, 210, 30), "Presiona 'F' para activar el ascensor");
        }
    }
    IEnumerator Fade()
    {   
        yield return new WaitForSeconds(1);
        float i = 0;
        while(i <= 1)
        {
            color.a = i;
            i += 0.03f;
            winBG.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
}