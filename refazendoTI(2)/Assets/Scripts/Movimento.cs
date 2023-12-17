using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private float speed = 40;
    
    private float cronometro = 0;

    void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        Destroy(this.gameObject, 3.0f);
    }
    void FixedUpdade()
    {
        if(speed < 70){
        cronometro += Time.deltaTime;
        speed += (cronometro/10);
        }
    }
    
}
