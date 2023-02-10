using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCinematica : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject nave;

    public void FinCinematica()
    {
        nave.SetActive(true);

    }

}
