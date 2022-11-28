using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioCtlr : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {

        if (slider == null)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        }
        else
        {
            slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        }
    }

    public void SetLevel()
    {
        float sliderValue = slider.value;
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);

        AudioListener.volume = sliderValue;
    }
}
