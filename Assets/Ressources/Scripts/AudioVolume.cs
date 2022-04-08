using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.value = AudioListener.volume;
    }

    private void Update()
    {
        //GameManager.mainVolume = slider.value;
        AudioListener.volume = slider.value;
    }
}
