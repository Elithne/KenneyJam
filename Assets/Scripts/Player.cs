using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //Detectar sus colisiones

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta; //Diferencia de movimiento

    private void Start(){
        //Elegir el boxCollider que se va a guardar
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //Sigue el mismo frame que la fìsica, se utiliza para movimiento y animaciones.
    private void FixedUpdate(){
        
        
        float x = Input.GetAxisRaw("Horizontal"); //Devuelve -1, 0, 1
        float y = Input.GetAxisRaw("Vertical"); //Devuelve -1, 0, 1

        //Resetear moveDelta para que el personje se quede quieto
        moveDelta = new Vector3(x,y,0);

        //Dar vuelta el sprite
        if(moveDelta.x > 0){
            transform.localScale = Vector3.one;
        } else if(moveDelta.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Mover al personaje
        transform.Translate(moveDelta * Time. deltaTime);
    }

}
