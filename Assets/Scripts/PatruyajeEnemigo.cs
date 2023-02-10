using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatruyajeEnemigo : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    Vector3 siguientePosicion;
    public float speed = 2f;
    float distanciaCambio = 1f;
    int numeroSiguientePosicion=0;
    GameObject target;
    void Start()
    {
          siguientePosicion = waypoints[0].position;
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, siguientePosicion, speed * Time.deltaTime);
        transform.LookAt(siguientePosicion);

        if (Vector3.Distance(transform.position, siguientePosicion)< distanciaCambio)
        {
            numeroSiguientePosicion++;
            if (numeroSiguientePosicion >= waypoints.Length)
            {
                numeroSiguientePosicion = 0;
            }
                siguientePosicion = waypoints[numeroSiguientePosicion].position;
            


        }
    }
}
