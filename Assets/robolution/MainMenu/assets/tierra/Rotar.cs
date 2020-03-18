using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    public Transform referente;
    public int velocidad = 1;

    void Start()
    {
      if(referente == null)
      {
        referente = this.gameObject.transform;
        Debug.Log("Nos falta un referente");
      }

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(referente.transform.position,referente.transform.up,velocidad * Time.deltaTime);
    }
}
