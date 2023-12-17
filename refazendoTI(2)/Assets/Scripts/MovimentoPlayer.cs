using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    private Transform[] paths;
    public int currentPathIndex = 1;
    Vector2 startPos, direction;
    public float distanciaMin = 15f;
    public float moveSpeed = 90f;
    private Vector3 targetPosition;
    
    public Animator animator;
    private int vida;
    private bool pulando = false;

    void OnEnable()
    {

        RouteManager routeManager = FindObjectOfType<RouteManager>();
        paths = routeManager.rotas;
        targetPosition = paths[1].position;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                break;

                case TouchPhase.Ended: direction = touch.position - startPos;
                    if (direction.x > distanciaMin)Changelane(1);
                        
                    else if (direction.x< - distanciaMin) Changelane(-1);
                break;
            }
            animator.SetBool("isJumping", true);
        }
        else animator.SetBool("isJumping", false);
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }
    public void Changelane(int direction)
    {
        int newPathIndex = currentPathIndex + direction;
        if (newPathIndex >= 0 && newPathIndex< paths.Length)
        {
            currentPathIndex = newPathIndex;
            targetPosition = new Vector3(paths[currentPathIndex].position.x, paths[currentPathIndex].transform.position.y, paths[currentPathIndex].transform.position.z);
        
        }
    }
    public AtivarColetaveis ativarColetaveis;
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag=="Vida")
        {
            ativarColetaveis.SomarPontos(10);
        }
        else if(other.CompareTag("DobrarPontos")) ativarColetaveis.DobrarPontos();
        else if(other.CompareTag("RecuperarVida")) ativarColetaveis.RecuperarVida();
        
        Destroy(other.gameObject);
    }
    public void FimPulo()
    {
        pulando = false;
    }
    public void Pulo()
    {
        pulando = true;
    }
   
    
    
}
