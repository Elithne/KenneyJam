using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //Detectar sus colisiones

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta; //Diferencia de movimiento
    private RaycastHit2D hit; //Para chequear si puedo moverme a ese lugar
    public float moveSpeed = 5f;

    private void Start(){
        //Elegir el boxCollider que se va a guardar
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //Sigue el mismo frame que la fìsica, se utiliza para movimiento y animaciones.
    private void FixedUpdate(){
        
        
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed; //Devuelve -1, 0, 1
        float y = Input.GetAxisRaw("Vertical") * moveSpeed; //Devuelve -1, 0, 1

        //Resetear moveDelta para que el personaje se quede quieto
        moveDelta = new Vector3(x,y,0);

        //Dar vuelta el sprite
        if(moveDelta.x > 0){
            transform.localScale = Vector3.one;
        } else if(moveDelta.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Mover al personaje en esta dirección, casteando primero una box. Si la box devuelve null, nos podemos mover. 
        //En el inspector de capas, hay que desactivar Queries Start in Collider para que el jugador no colisione consigo mismo. 
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,  0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));

        if(hit.collider == null){
            transform.Translate(0, moveDelta.y * Time. deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position,boxCollider.size,  0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));

        if(hit.collider == null){
            transform.Translate(moveDelta.x * Time. deltaTime, 0, 0);
        }
        
    }

}
