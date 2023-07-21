using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : Collidable
{
    public PlayerGrabKey playerGrabKey; // Referencia al componente PlayerGrabKey del jugador
    public GameObject door; // Referencia al GameObject de la puerta que se va a abrir
    private bool isLocked = true; // Variable para controlar el estado de la puerta (bloqueada o abierta)

    protected override void OnCollide(Collider2D col)
    {
        // Verificar si el objeto con el que colisionó tiene el nombre "Player" y si la puerta está bloqueada
        if (col.name == "Player" && isLocked)
        {
            // Verificar si el jugador tiene una llave
            if (playerGrabKey.hasKey())
            {
                Debug.Log("I open the door"); // Imprime un mensaje en la consola con el fin de depuración
                door.SetActive(false); // Desactiva el GameObject de la puerta para simular que ha sido abierta
                isLocked = false; // Marcar la puerta como desbloqueada
            }
            else
            {
                Debug.Log("The door is locked. You need a key!"); // Imprimir un mensaje en la consola si la puerta está bloqueada y el jugador no tiene una llave
            }
        }
    }
}