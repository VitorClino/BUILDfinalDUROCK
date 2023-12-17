using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derrota : MonoBehaviour
{
    AtivarColetaveis ativarColetaveis = new AtivarColetaveis();
    int auxVida;
    public GameObject derrota;
    void Start()
    {
        int auxVida = ativarColetaveis.vida;
    }

    private void Update()
    {
        if(auxVida <= 0 && Time.deltaTime == 1.0f)
        {
            Perder();
        }
    }
    public void Perder()
    {
        derrota.SetActive(true);
    }
}
