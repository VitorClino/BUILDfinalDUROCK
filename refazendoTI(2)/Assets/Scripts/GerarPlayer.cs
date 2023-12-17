using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarPlayer : MonoBehaviour
{
    public Transform spawn;
    public GameObject[] player;

    private static string qualPlayer = EscolherPersonagem.QualPlayer;
    
    void OnEnable()
    {
        
        Vector3 posicaoInicial = spawn.position;
        if (qualPlayer == "PlayerVermelho" || qualPlayer == null){GameObject playerAtual = Instantiate(player[0], posicaoInicial, transform.rotation);}
        if(qualPlayer == "PlayerRoxo"){GameObject playerAtual = Instantiate(player[1], posicaoInicial, transform.rotation);}
        
    }
}
