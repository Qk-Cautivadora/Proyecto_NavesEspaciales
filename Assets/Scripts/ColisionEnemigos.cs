using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionEnemigos : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    private void OnCollisionEnter (Collision col)
    {
        if( col.gameObject.tag == "Proyectil" || col.gameObject.tag == "Player")
        {
            Debug.Log("Colision Detectada");
            this.gameObject.SetActive(false);
            Instantiate(explosion, transform.position, Quaternion.identity);
            
        }
    }
}
