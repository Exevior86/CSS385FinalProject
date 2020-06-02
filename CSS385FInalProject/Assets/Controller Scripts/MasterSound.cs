using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterSound : MonoBehaviour
{
    public GameObject slider;
    private static float value = .5f;
    private void Start()
    {
        slider.GetComponent<Slider>().value = value;
    }
    void Update()
    {
        AudioListener.volume = value;
    }

    public void SetLevel(float sliderValue)
    {
        value = sliderValue;
    }
}
