using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void ToggleSound()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void Back()
    {
        SceneManager.LoadScene("menu");
    }
}