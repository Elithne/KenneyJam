using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit; 
    public float moveSpeed = 8f;

    protected virtual void Start(){
        
        boxCollider = GetComponent<BoxCollider2D>();
    }


    protected virtual void UpdateMotor(Vector3 input){
        // Crear un vector que representa el movimiento deseado en el frame actual
        moveDelta = new Vector3(input.x*moveSpeed, input.y*moveSpeed, 0);
         
         // Cambiar la escala del jugador para voltearlo en la dirección del movimiento horizontal
               
        if(moveDelta.x > 0){
            transform.localScale = Vector3.one;
        } else if(moveDelta.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        moveDelta += pushDirection;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        /*realiza una detección de colisiones utilizando una caja rectangular desde la posición actual del jugador, en la dirección vertical (moveDelta.y) con una distancia igual a la magnitud del movimiento vertical en un solo frame. Si encuentra un objeto con Layer Actor o Blocking, devuelve eso. Sino, devuelve null y se mueve.     
        En el inspector de capas, hay que desactivar Queries Start in Collider para que el jugador no colisione consigo mismo.*/
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,  0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));

        // Si no hay colisión, mover el jugador en el eje y (arriba/abajo)
        if(hit.collider == null){
            transform.Translate(0, moveDelta.y * Time. deltaTime, 0);
        }

        // Realizar una detección de colisión en el eje horizontal para evitar colisiones con otros objetos
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,  0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));

        // Si no hay colisión, mover el jugador en el eje x (izquierda/derecha)
        if(hit.collider == null){
            transform.Translate(moveDelta.x * Time. deltaTime, 0, 0);
        }
    }
}
