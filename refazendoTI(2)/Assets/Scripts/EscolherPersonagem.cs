using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolherPersonagem : MonoBehaviour
{
    public GameObject[] player;
    private GameObject auxPlayer;

    public GameObject panel;
    public GameObject play;
    public Vector3 spawn;
    private static string qualPlayer;
    private int intQualPlayer = 0;

    void Start()
    {
        auxPlayer = Instantiate(player[intQualPlayer], spawn, transform.rotation);
    }
    public void CriarPlayer(int i)
    {
        int j =0;
        if (i==1)
        {
            j=i;
            Destroy(auxPlayer);
            auxPlayer = Instantiate(player[j], spawn, transform.rotation);
        }
        if (i==(-1))
        {
            j=0;
            Destroy(auxPlayer);
            auxPlayer = Instantiate(player[j], spawn, transform.rotation);
        }
        if (auxPlayer.tag == "PlayerVermelho") 
        {
            qualPlayer="PlayerVermelho";
            intQualPlayer = 0;
            play.SetActive(true);
            panel.SetActive(false);
        }
        if(auxPlayer.tag == "PlayerRoxo") 
        {
            qualPlayer="PlayerRoxo";
            intQualPlayer = 1;
            play.SetActive(false);
            panel.SetActive(true);

        }
    }
    public static string QualPlayer
    {
        get {return qualPlayer;}
        set {qualPlayer = value;}
    }
}
