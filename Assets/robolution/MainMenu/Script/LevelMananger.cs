using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMananger : MonoBehaviour
{  
    public void Carganivel(string nivel)
    {
        SceneManager.LoadScene(nivel);
    }  

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    } 

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
