using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarPause : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject canva;

    void Start()
    {
        menuPausa.SetActive(false);
    }

    public void Pausar()
    {
        if (Time.timeScale == 0f) 
        {
            ResumeGame();
        }
        else 
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        menuPausa.SetActive(true);
        canva.SetActive(false);
    }

    public void ResumeGame()
    {   
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        canva.SetActive(true);
    }
}
