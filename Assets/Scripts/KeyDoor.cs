using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : Collidable
{
    public PlayerGrabKey playerGrabKey; // Referencia al componente PlayerGrabKey del jugador
    public Door door; // Referencia al GameObject de la puerta que se va a abrir
    public bool isLocked; // Variable para controlar el estado de la puerta (bloqueada o abierta)
    public bool isClosed;
    private Vector3 offset = new Vector3(0, 2f, 0);
    

    protected override void OnCollide(Collider2D col){
        // Verificar si el objeto con el que colisionó tiene el nombre "Player" y si la puerta está bloqueada
        if (col.name == "Player"){
            if(isLocked){
                isClosed = true;
                // Verificar si el jugador tiene una llave
                if (playerGrabKey.HasKey()){
                    isLocked = false; // Marcar la puerta como desbloqueada
                    playerGrabKey.RemoveKey();
                }else{
                    GameManager.instance.ShowText("The door is locked. You need a key!", 25, Color.white, transform.position + offset, Vector3.zero, 0.01f);// Imprimir un mensaje si la puerta está bloqueada y el jugador no tiene una llave
                }
            }else{
                GameManager.instance.ShowText("Press F", 25, Color.white, transform.position + offset, Vector3.zero, 0.01f);
                if(Input.GetKeyDown(KeyCode.F)){
                    if(isClosed){
                        door.Open();
                        isClosed = false;  
                    } else {                 
                        door.Close();
                        isClosed = true;
                    } 
                }   
            }
                
        }
    }
}