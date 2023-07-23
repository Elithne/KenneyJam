using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite openChest; // Sprite que se mostrará cuando el cofre esté abierto
    public PlayerGrabKey playerGrabKey; // Referencia al componente PlayerGrabKey del jugador
    private Vector3 chestOffset = new Vector3(0, 0.7f, 0);

    protected override void OnCollect()
    {
        // Verificar si se presionó la tecla F y el cofre aún no ha sido recogido
        if (Input.GetKeyDown(KeyCode.F) && !collected)
        {
            // Cambiar el sprite del cofre al sprite de cofre abierto
            GetComponent<SpriteRenderer>().sprite = openChest;

            // Llamar a la función addKey() del componente PlayerGrabKey del jugador para agregar una llave
            playerGrabKey.AddKey();
            GameManager.instance.ShowText("Key obtained!", 25, Color.yellow, transform.position + chestOffset, Vector3.up * 50, 1.5f);

            collected = true; // Marcar el cofre como recogido para que no pueda ser recogido nuevamente
        }
    }
}