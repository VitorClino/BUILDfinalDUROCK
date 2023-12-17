using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditarSom : MonoBehaviour
{
    public AudioSource audioGlobal;

    public void MudarVolume(Slider slider)
    {
        float volume = slider.value;
        audioGlobal.volume = volume;
    }
}
