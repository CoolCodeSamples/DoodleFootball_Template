using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;
    
    public void Spawn()
    { 
        Instantiate(powerUps[Random.Range(0,powerUps.Length)],transform.position,transform.rotation);
    }
}


