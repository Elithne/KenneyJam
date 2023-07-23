using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // Cantidad máxima de vidas
    private int currentLives; // Vidas actuales del personaje

    private void Start()
    {
        // Recuperar el número actual de vidas desde PlayerPrefs si existe, o usar el valor por defecto si no.
        currentLives = PlayerPrefs.GetInt("PlayerLives", maxLives);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Ejemplo: perder una vida al presionar la tecla Espacio (Para probar si funka).
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentLives -= damageAmount;

        if (currentLives <= 0)
        {
            // Aca se ejecuta la lógica si el personaje se queda sin vidas, cosas como reiniciar el nivel o mostrar un Game Over.
            // Por ejemplo:
            // SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            // Guardar las vidas actuales en PlayerPrefs para que persistan a través de las escenas.
            PlayerPrefs.SetInt("PlayerLives", currentLives);

            // Recargar la escena actual (o cambiar a otra escena) después de perder una vida.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}