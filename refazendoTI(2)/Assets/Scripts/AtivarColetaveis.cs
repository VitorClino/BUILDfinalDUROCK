using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtivarColetaveis : MonoBehaviour
{
    public int vida = 2;
    public int pontos = 0;
    public Text mVida;
    public Text mPontos;
    public bool dobrar = false;
    public int velocidadeAlmentada = 70;


    public GameObject derrota;
    public Animator animator;

    public GameObject somDano;

    public void OnEnable()
    {
        animator = GetComponent<Animator>();
    }
    
    public void DiminuirVida()
    {
        if(vida> 0 && PlayerPrefs.HasKey("TutorialCompleted"))
        {
            vida--;
        }
        TakeDamage();
        
    }
    
    public void DobrarPontos()
    {
        dobrar = true;
        Invoke("FimDeDobrar", 10f);
    }
    void FimDeDobrar(){dobrar = false;}

    public void SomarPontos(int auxPontos)
    {
        if(dobrar)
        pontos += (auxPontos*2);

        else
        pontos += auxPontos;
    }

    public void RecuperarVida()
    {
        if (vida<7)vida++;
    }

    public void FixedUpdate()
    {
        mVida.text = $"Vida : {vida}";
        mPontos.text = $"Pontos : {pontos}";

        if(vida <= 0)
        {
            Perder();
        }
    }
    public void Perder()
    {
        animator.SetBool("isDead", true);
    }
    public void FimMovimento()
    {
        derrota.SetActive(true);
    }
    
    private void TakeDamage()
    {
        somDano.SetActive(true);
        Invoke("Desativa",1.0f);
    }
    void Desativa()
    {
        somDano.SetActive(false);
    }

}
