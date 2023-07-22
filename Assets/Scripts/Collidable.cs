using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter; // Filtro para controlar qué objetos colisionarán con este objeto
    private BoxCollider2D boxCollider; // Referencia al BoxCollider2D del objeto
    private Collider2D[] hits = new Collider2D[10]; // Array para almacenar los colliders que colisionan con este objeto

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>(); // Obtener la referencia al BoxCollider2D del objeto
    }

    protected virtual void Update()
    {
        // Realizar una detección de colisiones utilizando el BoxCollider2D y el filtro especificado
        boxCollider.OverlapCollider(filter, hits);

        // Iterar sobre los colliders que colisionan con este objeto
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            // Llamar a la función OnCollide() para manejar la colisión con el collider específico
            OnCollide(hits[i]);
            hits[i] = null;
        }
    }

    // Función virtual que se puede modificar en clases derivadas para manejar las colisiones
    protected virtual void OnCollide(Collider2D col)
    {
        // muestra el nombre del objeto con el que colisionó
        if (col.name == "Player"){
            Debug.Log(col.name);
        }    
    }
}