using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void Start(){
        lookAt = GameObject.Find("Player").transform;
        }

    //Se llama luego del FixedUpdate, es para que la camara se mueva luego.
    private void LateUpdate(){
        Vector3 delta = Vector3.zero; //Diferencia entre un frame y el siguiente.

        float deltaX = lookAt.position.x - transform.position.x; //Conseguimos la distancia entre la posición de foco, y el jugador.
        
        //Chequeamos si estamos fuera del boundX
        if(deltaX > boundX || deltaX < - boundX){
            if(transform.position.x < lookAt.position.x){ // si es verdadero, el jugador está a la derecha y está enfocando hacia la derecha
                delta.x = deltaX - boundX;
            } else{
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = lookAt.position.y - transform.position.y; //Conseguimos la distancia entre la posición de foco, y el jugador.
        
        //Chequeamos si estamos fuera del boundY
        if(deltaY > boundY || deltaY< - boundY){
            if(transform.position.y < lookAt.position.y){ // si es verdadero, el jugador está a la derecha y está enfocando hacia la derecha
                delta.y = deltaY - boundY;
            } else{
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}


