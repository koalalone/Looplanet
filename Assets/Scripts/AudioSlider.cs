using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] Slider slider;


    public void SetVolume()
    {
        AudioManager.instance.SetMusicVolume(slider.value);
        AudioManager.instance.SetSFXVolume(slider.value);
    }
}
