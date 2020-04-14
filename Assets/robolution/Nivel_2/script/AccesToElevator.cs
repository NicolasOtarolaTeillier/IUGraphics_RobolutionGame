using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AccesToElevator : MonoBehaviour
{


    private bool _isEnter = false;

    public bool _credential = false;

    public GameObject _luzV;

    public GameObject _luzR;

    //cambiar nivel
    public GameObject door_1_left;
 
    public GameObject door_1_right;

    AudioSource elevatorSound;
    public Image winBG;
    public Color color;

    private bool unaVez = true;

    // Start is called before the first frame update
    void Start()
    {
        elevatorSound = GetComponent<AudioSource>();
        winBG.enabled = true;
        color = winBG.color;
        _luzR.SetActive(true);
        _luzV.SetActive(false);
        
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("dentro");
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player Sofronov = other.GetComponent<Player>();
                if (Sofronov != null)
                {
                    _credential = Sofronov.getCredential();
                    if (_credential){
                        if(!elevatorSound.isPlaying && unaVez)
                        {
                            
                            _luzR.SetActive(false);
                            _luzV.SetActive(true);
                            door_1_left.SetActive(true);
                            door_1_right.SetActive(true);
                            elevatorSound.Play();
                            StartCoroutine(Fade());
                            unaVez = false;
                        }
                        
                        
                    }

                }
            }
        }
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
    private void OnGUI()
    {
        if (_isEnter)
        {
            if(!_credential)
            {
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 60), "Encuentra tu credencial");
            }
            if (_credential)
            {
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 60), "Presiona 'E' para activar el ascensor");
            }
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
