using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarScene : MonoBehaviour
{
    public void CarregarCenaDestino(string cenaDestino )
    {
        SceneManager.LoadScene(cenaDestino);
    }
    
}
