using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credential : MonoBehaviour
{
    [SerializeField]
    private GameObject _credentialSofronov;
    
    [SerializeField]
    private bool _isEnter = false;

    // Start is called before the first frame update
    void Start(){}

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
                    Sofronov.uploadCredential(true);
                    _credentialSofronov.SetActive(false);
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
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 60), "Sofronov credential, presione 'E'");
        }    
    }
}
