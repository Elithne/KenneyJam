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
//Con esto pasamos el nombre de la escena a texto
    private string currentScene;

    protected override void Death(){

        currentScene = SceneManager.GetActiveScene().name; // Almacenamos el nombre de la escena actual
        SceneManager.LoadScene(currentScene);//Cargamos la escena actual cuando muere
        //SceneManager.LoadScene("Level1");
    }

}