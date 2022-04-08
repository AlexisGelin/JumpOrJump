using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    public Slider slider;

    private void Update()
    {
        AudioListener.volume = slider.value;
    }
}
