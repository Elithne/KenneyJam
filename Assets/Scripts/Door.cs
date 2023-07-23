using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioClip openSound; // Sonido de apertura de la puerta.
    public AudioClip closeSound; // Sonido de cierre de la puerta.
    private AudioSource audioSource; // Referencia al componente AudioSource de la puerta.

    public void Open(){
        Invoke("PlaySound", 3);
        gameObject.SetActive(false);
        
    }

    public void PlaySound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(openSound);
    }

    public void Close(){
        gameObject.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(closeSound);
    }
}
