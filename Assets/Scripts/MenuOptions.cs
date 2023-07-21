using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void ToggleSound()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        Debug.Log(Mute.);
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log(Fullscren.);
    }

    public void Back()
    {
        SceneManager.LoadScene("menu");
        Debug.Log(Inicio.);
    }
}