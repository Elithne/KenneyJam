using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private void Start()
    {
        // Asegúrate de que el volumen esté configurado correctamente al inicio
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = savedVolume;
            audioSource.volume = savedVolume;
        }
    }

    public void OnVolumeChanged()
    {
        // Cambiar el volumen del audioSource según el valor del slider
        audioSource.volume = volumeSlider.value;

        // Guardar el valor del volumen para futuras sesiones
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
