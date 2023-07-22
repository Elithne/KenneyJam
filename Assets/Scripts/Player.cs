using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : Mover
{
    private void FixedUpdate(){  
        // Obtener la entrada del eje horizontal (izquierda/derecha) y vertical (arriba/abajo) del teclado
        float x = Input.GetAxisRaw("Horizontal"); 
        float y = Input.GetAxisRaw("Vertical");  

        UpdateMotor(new Vector3(x, y, 0));          
    }

    protected override void Death(){
        SceneManager.LoadScene("Level1");
    }

}