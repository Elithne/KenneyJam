using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10]; //Maxima cantidad de elementos con las que vamos a registrar colisión

    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>(); //Requiere el collider2D del elemento con el que colisiona.
    }

    protected virtual void Update() {
        boxCollider.OverlapCollider(filter, hits); // toma nuestro filter y nuestro array para buscar algo que poner dentro dde él.

        for (int i = 0; i < hits.Length; i++){
            if(hits[i] == null){
                continue;
            }
                         
            OnCollide(hits[i]);
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D col){ //Si son virtual, se pueden modificar :D)
        Debug.Log(col.name);
    }
}
