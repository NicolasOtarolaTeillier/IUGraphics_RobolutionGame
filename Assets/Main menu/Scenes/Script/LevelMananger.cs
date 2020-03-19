using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMananger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void Carganivel(string nivel){
        SceneManager.LoadScene(nivel);
    }

    public void Salir(){
      Application.Quit();
      Debug.Log("Salir");
    }

}
