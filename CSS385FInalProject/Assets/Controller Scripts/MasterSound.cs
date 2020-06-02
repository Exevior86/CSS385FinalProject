using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterSound : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject slider;
    private static float value = .5f;

    void Update()
    {
        slider.GetComponent<Slider>().value = value;
        AudioListener.volume = value;
    }

    public void SetLevel(float sliderValue)
    {
        value = sliderValue;
    }
}
