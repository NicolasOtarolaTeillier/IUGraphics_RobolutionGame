using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Vida : MonoBehaviour
{
    public int vidaInicial = 100;
    public int vidaActual;
    public Slider barraVida;
    public Text muertoTxt;
    public Image muertoBG;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaInicial;
        barraVida.value = vidaInicial;
        muertoTxt.enabled = false;
        muertoBG.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(recibeDaño(10));
        }
    }

    IEnumerator recibeDaño(int d)
    {
        if(vidaActual <= d)
        {
            vidaActual = 0;
            muertoTxt.enabled = true;
            muertoBG.enabled = true;
            yield return new WaitForSeconds(0.7f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        else
        {
            vidaActual -= d;
        }        
        barraVida.value = vidaActual;       
    }
    
}
