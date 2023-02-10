using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    //Movimiento De La Nave
    public float speedRotationVertical = 10f;

    public bool pressingThrottle = false;
    public bool throttle => pressingThrottle;

    public float pitchPower, rollPower, yawPower, enginePower;

    private float activeRoll, activePitch, activeYaw;
    // Disparar Proyectiles
    [SerializeField] GameObject prefabProyectil;
    //destruirNave
    [SerializeField] GameObject explosion;
    public float cadenciaTiro = 0.75f;
    

    //efectoPowerUp
    public float tiempoEfecto;
    float tiempoRecogido;
    private void Update()
    {//MOVIMIENTO naVE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pressingThrottle == false)
            {

                pressingThrottle = true;

            }
            else if (pressingThrottle == true)
            {

                pressingThrottle = false;

            }
        }
        if (throttle)
        {
            transform.position += transform.up * enginePower * Time.deltaTime;

            activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * rollPower * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * yawPower * Time.deltaTime;

            transform.Rotate(activePitch * pitchPower * Time.deltaTime,
                activeYaw * yawPower * Time.deltaTime,
                activeRoll * rollPower * Time.deltaTime,
                Space.Self);

            float rotacionX = Input.GetAxis("Vertical") * speedRotationVertical * Time.deltaTime;
            transform.Rotate(rotacionX, 0f, 0f, Space.Self);
            float rotacionY = Input.GetAxis("Horizontal") * speedRotationVertical * Time.deltaTime;
            transform.Rotate(0f, rotacionY, 0f, Space.Self);
            float rotacionZ = Input.GetAxis("Horizontal") * speedRotationVertical * Time.deltaTime;
            transform.Rotate(0f, 0f, rotacionY, Space.Self);
        }
        else
        {
            activePitch = Input.GetAxisRaw("Vertical") * (pitchPower / 2) * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * (rollPower / 2) * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Yaw") * (yawPower / 2) * Time.deltaTime;

            transform.Rotate(activePitch * pitchPower * Time.deltaTime,
                activeYaw * yawPower * Time.deltaTime,
                activeRoll * rollPower * Time.deltaTime,
                Space.Self);
        }
        //DISPARAR (Profe, Como yo uso el espacio para acelerar, puse el ataque en el click izquierdo del raton)
        if (Input.GetMouseButtonDown(0))
        {
            Invoke("Disparar", cadenciaTiro);
        }
        //POWERUP
        if (tiempoRecogido > tiempoEfecto)
        {
            Efecto();
        }


    }

    public void Disparar()
    {
        Instantiate(prefabProyectil, transform.position + new Vector3 (0,1,0), transform.rotation);
    }

    //Destruir al chocar
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil")) { }
        else
        {
            gameObject.SetActive(false);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag( "PowerUP"))
        {
            tiempoRecogido = Time.time;
        }
    }

    private void Efecto()
    {
        cadenciaTiro /= 2;
    }
}
