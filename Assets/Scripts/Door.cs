using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Collidable
{
    
    public void Open(){
        gameObject.SetActive(false);
    }

    public void Close(){
        gameObject.SetActive(true);
    }
}
