using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioClip openSound; // Sonido de apertura de la puerta.
    public AudioClip closeSound; // Sonido de cierre de la puerta.
    private AudioSource audioSource; // Referencia al componente AudioSource de la puerta.

    public void Open(){
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(openSound);
        StartCoroutine(DisableAfterSound());
        
    }

    private IEnumerator DisableAfterSound()
        {
        // Esperar un tiempo determinado después de reproducir el sonido
        yield return new WaitForSeconds(openSound.length);

        // Desactivar la puerta después del tiempo de espera
        gameObject.SetActive(false);
    }

    public void Close(){
        gameObject.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(closeSound);
    }
}
