using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{   [SerializeField]
    Transform[] spawnPoints;
    [SerializeField] GameObject power;
    public float minTime, maxTime;
    bool activo = false;
    // Start is called before the first frame update
  
    private void Update()
    {   if (activo == true) { }
    else
        Invoke("Spawnear", Random.Range(Time.time + minTime, Time.time + maxTime));

    }

    public void Spawnear()
    {
        Instantiate(power, spawnPoints[Random.Range(0, spawnPoints.Length)]);
        activo = true;
    }

    private void OnTriggerEnter (Collider Player)
    {
        if (Player.gameObject.CompareTag("Player")) {Destroy(Player.gameObject,0); activo = false; }
    }
}
