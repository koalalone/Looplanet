using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public PostProcessProfile profil;
    ChromaticAberration chromatic;
    ColorGrading color;

    private void Start()
    {
        //volume = GetComponent<PostProcessVolume>();
        profil.TryGetSettings<ChromaticAberration>(out chromatic);
        profil.TryGetSettings<ColorGrading>(out color);

        chromatic.intensity.value = 0;
        color.saturation.value = 0;
    }

    public void SetMaxHealth(int maxHealth)
    {  
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
        chromatic.intensity.value = 1 - slider.normalizedValue;
        color.saturation.value = (slider.normalizedValue * 100) - 100;
    }
}
