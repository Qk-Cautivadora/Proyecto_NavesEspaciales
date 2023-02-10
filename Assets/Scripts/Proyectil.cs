using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{   public float velocidad;
    

    void Update()
    {
        transform.position += transform.up * velocidad * Time.deltaTime;
        Destroy(gameObject, 2f);
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Debug.Log("enemigo Detectada");
            gameObject.SetActive(false);
           
        }
    }
}
