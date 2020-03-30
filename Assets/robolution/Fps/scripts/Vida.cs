using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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
            recibeDaño(10);
        }
    }

    public void recibeDaño(int d)
    {
        if(vidaActual <= d)
        {
            vidaActual = 0;
            muertoTxt.enabled = true;
            muertoBG.enabled = true;
        }
        else
        {
            vidaActual -= d;
        }        
        barraVida.value = vidaActual;       
    }
}
