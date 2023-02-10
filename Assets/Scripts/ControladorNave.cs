using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNave : MonoBehaviour
{
    public float speed = 1;
    public float speedRotationVertical = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotacionX = Input.GetAxis("Vertical") * speedRotationVertical* Time.deltaTime;
        transform.Rotate(rotacionX, 0f, 0f, Space.Self);
        float rotacionY = Input.GetAxis("Horizontal") * speedRotationVertical * Time.deltaTime;
        transform.Rotate(0f, rotacionY, 0f, Space.Self);
        float rotacionZ = Input.GetAxis("Horizontal") * speedRotationVertical * Time.deltaTime;
        transform.Rotate(0f, 0f, rotacionY, Space.Self);
        transform.position += (transform.up * Time.deltaTime * speed);

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 4;
        }
        */


    }
}
