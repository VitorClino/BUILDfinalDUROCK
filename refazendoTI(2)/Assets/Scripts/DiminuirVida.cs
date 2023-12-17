using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiminuirVida : MonoBehaviour
{
    public AtivarColetaveis ativarColetaveis;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Vida"))ativarColetaveis.DiminuirVida();
        
        Destroy(collider.gameObject);
    }
}
