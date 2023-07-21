using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log(Play.);
    }

    public void Information()
    {
        SceneManager.LoadScene("Information");
        Debug.Log(Info.);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
        Debug.Log(Options.);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log(Exit.);
    }
}