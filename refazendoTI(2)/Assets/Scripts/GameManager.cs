using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Awake()
    {
        Time.timeScale = 0;
    }
    void OnEnable()
    {
        Time.timeScale = 0;
    }

}
