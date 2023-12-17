using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    
    public GameObject nota;
    public GameObject recuperarVida;
    public GameObject acelerador;
    public Transform[] noteSpawnPoints;
    GameObject newNota;
    public GameObject canvaNota, canvaRecuperarVida ,canvaDobroPontos, canvaSuperPontos;
    public GameObject canvaMuitoBem, canvaParabens, canvaVamosProRock;
    private float spawnRate = 1.8f;


    void Start()
    {
        ResetTutorial();
        //LEMBRA DE DIRA O RESET QUANDO FOR BUILDAR
        if(!PlayerPrefs.HasKey("TutorialCompleted"))Tutorial();
        else {
            ComecaJogo();
        }

    }
    private void  ComecaJogo()
    {
        InvokeRepeating("CreateNote", 1f, spawnRate);
        InvokeRepeating("CreateBuff", 1f, 5.5f);
    }
    public void CreateNote()
    {
        int rdm = Random.Range(0, 3);
        Vector3 spawn = noteSpawnPoints[rdm].position;
        newNota = Instantiate(nota, spawn, transform.rotation);
    }

    public void CreateBuff()
    {
        int rdm = Random.Range(0,3);
        Vector3 spawn = noteSpawnPoints[rdm].position;

        int buff = Random.Range(0, 2);
        if(buff == 0)RecuperarVida(spawn);
        else if (buff ==1)Acelerar(spawn);
    }

    public void CreateBuffDefinido(int buff)
    {
        int rdm = Random.Range(0,3);
        Vector3 spawn = noteSpawnPoints[rdm].position;

        if(buff == 0)RecuperarVida(spawn);
        else if (buff ==1)Acelerar(spawn);
    }
    public void RecuperarVida(Vector3 spawn)
    { 
        GameObject newBuff = Instantiate(recuperarVida, spawn, transform.rotation);
        Destroy(newBuff, 3f);
    }
    public void Acelerar(Vector3 spawn)
    {
        GameObject newBuff = Instantiate(acelerador, spawn, transform.rotation);
        Destroy(newBuff, 3f);
    }
    private void Tutorial()
    {
        StartCoroutine(ExibirTutorialPorTempo());
    }
    IEnumerator ExibirTutorialPorTempo()
    {
        yield return new WaitForSeconds(1f);
        canvaNota.SetActive(true);

        yield return new WaitForSeconds(1f);
        for(int i = 0; i<3; i++)
        {
            CreateNote();
            yield return new WaitForSeconds(2f);
        }
        canvaNota.SetActive(false);
        yield return new WaitForSeconds(1f);

        canvaMuitoBem.SetActive(true);
        yield return new WaitForSeconds(2f);
        canvaMuitoBem.SetActive(false);

        yield return new WaitForSeconds(1f);
        canvaRecuperarVida.SetActive(true);
        CreateBuffDefinido(1);
        yield return new WaitForSeconds(2f);
        for(int i = 0; i<2; i++)
        {
            CreateNote();
            yield return new WaitForSeconds(2f);
        }
        canvaRecuperarVida.SetActive(false);
        yield return new WaitForSeconds(1f);

        canvaParabens.SetActive(true);
        yield return new WaitForSeconds(2f);
        canvaParabens.SetActive(false);
        
        yield return new WaitForSeconds(1f);
        canvaDobroPontos.SetActive(true);
        yield return new WaitForSeconds(3f);
        for(int i = 0; i<2; i++)
        {
            CreateBuffDefinido(0);
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(2f);

        canvaDobroPontos.SetActive(false);
        yield return new WaitForSeconds(2f);

        canvaVamosProRock.SetActive(true);
        yield return new WaitForSeconds(2f);
        canvaVamosProRock.SetActive(false);
        
        ComecaJogo();
        PlayerPrefs.SetInt("TutorialCompleted", 1);
    }

    void ResetTutorial()
    {
        PlayerPrefs.DeleteKey("TutorialCompleted");
    }
    
}