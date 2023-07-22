using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuButtonController : MonoBehaviour
{
    public Button[] menuButtons; // Array para almacenar los botones del menú
    public AudioClip selectSound; // Sonido al seleccionar un botón
    public AudioClip navigateSound; // Sonido al navegar entre botones

    private AudioSource audioSource;
    private int selectedButtonIndex = 0; // Índice del botón seleccionado

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Detectar el movimiento vertical del mouse o las flechas
        float verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(verticalInput) > 0.1f)
        {
            // Navegar entre los botones
            Navigate(verticalInput);
        }

        // Detectar el clic del mouse o la tecla "Enter" para seleccionar el botón
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
        {
            SelectButton(selectedButtonIndex);
        }
    }

    private void Navigate(float direction)
    {
        // Restaurar el color del botón actual
        menuButtons[selectedButtonIndex].image.color = Color.white;

        // Calcular el nuevo índice del botón seleccionado
        selectedButtonIndex += (int)Mathf.Sign(direction);

        // Asegurarse de que el índice esté dentro de los límites del arreglo
        selectedButtonIndex = Mathf.Clamp(selectedButtonIndex, 0, menuButtons.Length - 1);

        // Resaltar el nuevo botón seleccionado


        // Reproducir el sonido de navegación
        PlaySound(navigateSound);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Play.");
    }

    public void Information()
    {
        SceneManager.LoadScene("Information");
        Debug.Log("Info.");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
        Debug.Log("Options.");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit.");
    }

    private void SelectButton(int index)
    {
         // Reproducir el sonido de selección
        PlaySound(selectSound);

   
        Debug.Log("Botón seleccionado: " + menuButtons[index].name);
    }

    private void PlaySound(AudioClip clip)
    {
        // Reproducir el sonido a través del componente AudioSource
        audioSource.PlayOneShot(clip);
    }
     public void OnButtonClick(int buttonIndex)
    {
        SelectButton(buttonIndex);
    }
}
