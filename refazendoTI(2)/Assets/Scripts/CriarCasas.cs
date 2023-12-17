using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarCasas : MonoBehaviour
{
    public GameObject casa;
    public Transform spawnCasa;
    
    void Start()
    {
        InvokeRepeating("CreateCasa", 0.5f, 0.5f);
    }
    public void CreateCasa()
    {
        Vector3 auxSpawnCasa = spawnCasa.position;
        GameObject auxCasa = Instantiate(casa,auxSpawnCasa, transform.rotation);
    }
}
