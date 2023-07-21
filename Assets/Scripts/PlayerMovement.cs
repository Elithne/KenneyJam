using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit; 
    public float moveSpeed = 5f;

    private void Start(){
        
        boxCollider = GetComponent<BoxCollider2D>();
    }

    
    private void FixedUpdate(){  
        // Obtener la entrada del eje horizontal (izquierda/derecha) y vertical (arriba/abajo) del teclado
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed; 
        float y = Input.GetAxisRaw("Vertical") * moveSpeed; 

        // Crear un vector que representa el movimiento deseado en el frame actual
        moveDelta = new Vector3(x,y,0);
         
         // Cambiar la escala del jugador para voltearlo en la dirección del movimiento horizontal
               
        if(moveDelta.x > 0){
            transform.localScale = Vector3.one;
        } else if(moveDelta.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }

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
