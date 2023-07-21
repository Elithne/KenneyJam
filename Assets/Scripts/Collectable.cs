using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected; // Variable que indica si el objeto ha sido recogido o no

    protected override void OnCollide(Collider2D col)
    {
        // Verificar si el objeto con el que colisionó tiene el nombre "Player"
        if (col.name == "Player")
        {
            //GameManager.instance.ShowText("Press F", 25, Color.white, transform.position, Vector3.up * 50, 3.0f);
            OnCollect(); // Llamar a la función OnCollect() para recoger el objeto
        }
    }

    protected virtual void OnCollect()
    {
        collected = true; // Marcar el objeto como recogido
    }
}