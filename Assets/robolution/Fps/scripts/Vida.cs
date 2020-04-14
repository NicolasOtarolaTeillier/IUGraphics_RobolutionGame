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

    VidaPlayer vida;
    
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<VidaPlayer>();
        vidaActual = vida.GetLife();
        barraVida.value = vida.GetLife();
        muertoTxt.enabled = false;
        muertoBG.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaActual != vida.GetLife())
        {
            StartCoroutine(recibeDaño(10));
            vidaActual = vida.GetLife();
            barraVida.value = vida.GetLife();
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
