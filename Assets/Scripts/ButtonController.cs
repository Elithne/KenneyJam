using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public AudioClip selectSound; // Sonido al seleccionar un botón
    public AudioClip navigateSound; // Sonido al navegar entre botones

    private AudioSource audioSource;
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Information()
    {
        SceneManager.LoadScene("Information");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}