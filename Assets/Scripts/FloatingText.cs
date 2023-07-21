using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    // Variables públicas
    public bool active; // Indica si el texto flotante está activo o no
    public GameObject go; // El objeto del texto flotante 
    public Text txt; // El componente Text que muestra el texto flotante
    public Vector3 motion; // La dirección y velocidad de movimiento del texto flotante
    public float duration; // La duración que el texto flotante estará visible
    public float lastShown; // El tiempo (en segundos) en el que se mostró por última vez el texto flotante

    // Función para mostrar el texto flotante
    public void Show()
    {
        active = true; // Activa el texto flotante
        lastShown = Time.time; // Guarda el tiempo actual
        go.SetActive(active); // Activa el GameObject del texto flotante
    }

    // Función para ocultar el texto flotante
    public void Hide()
    {
        active = false; // Desactiva el texto flotante
        go.SetActive(active); // Desactiva el GameObject del texto flotante
    }

    // Función para actualizar el texto flotante en cada frame
    public void UpdateFloatingText()
    {
        if (!active)
        {
            return; // Si el texto flotante no está activo, no hace nada
        }

        // Si ha pasado más tiempo del especificado en 'duration', se oculta el texto flotante
        if (Time.time - lastShown > duration)
        {
            Hide();
        }

        // Mueve el GameObject del texto flotante según la dirección y velocidad 'motion'
        go.transform.position += motion * Time.deltaTime;
    }
}
