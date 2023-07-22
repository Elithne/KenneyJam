using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteToggle;

    void Start()
    {
        // Inicializa el valor del slider y del toggle con los valores guardados en PlayerPrefs
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);
        muteToggle.isOn = PlayerPrefs.GetInt("Mute", 0) == 1;
    }

    public void OnVolumeChanged()
    {
        // Actualiza el volumen del AudioListener cuando se cambia el valor del slider
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);

    }

    public void OnMuteChanged()
    {
        // Actualiza el muteo del AudioListener cuando se cambia el valor del toggle
        AudioListener.pause = muteToggle.isOn;
        PlayerPrefs.SetInt("Mute", muteToggle.isOn ? 0 : 1);
        Debug.Log("Mute");
    }
}
