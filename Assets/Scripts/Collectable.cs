using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected; // Variable que indica si el objeto ha sido recogido o no
    private Vector3 textOffset = new Vector3(0, 1.2f, 0);

    protected override void OnCollide(Collider2D col)
    {
        // Verificar si el objeto con el que colisionó tiene el nombre "Player"
        if (col.name == "Player")
        {
            if (collected == false)
			{
				GameManager.instance.ShowText("Press F", 25, Color.white, transform.position + textOffset, Vector3.zero, 0.01f);
				OnCollect(); // Llamar a la función OnCollect() para recoger el objeto
			}
		}
    }

    protected virtual void OnCollect()
    {
        collected = true; // Marcar el objeto como recogido
    }
}