using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesToElevator : MonoBehaviour
{


    [SerializeField]
    private bool _isEnter = false;

    [SerializeField]
    public bool _credential = false;

    [SerializeField]
    private GameObject _luzV;
    [SerializeField]
    private GameObject _luzR;

    // Start is called before the first frame update
    void Start()
    {
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
                    if (_credential){
                        _luzR.SetActive(false);
                        _luzV.SetActive(true);
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
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 60), "Presiona la E para subir");
            }
        }
             
    }
}
