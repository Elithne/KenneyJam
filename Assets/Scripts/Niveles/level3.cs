using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : Collidable
{
    public void Level_3() 
    {
        
    }

     protected override void OnCollide(Collider2D col)
     {
        // Verificar si el objeto con el que colisionó tiene el nombre "Player" y si la puerta está bloqueada
        if (col.name == "Player")
        {
            SceneManager.LoadScene("Level3");
        }
     }
}
