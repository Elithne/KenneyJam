using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabKey : MonoBehaviour
{
    private int keys;

    private void Awake(){
        keys = 0;
    }

    public void addKey(){
        keys++;
        Debug.Log(keys);
    }

    public void removeKey(){
        if(keys <= 0){
            keys--;
        }       
    }

    public bool hasKey(){
        if(keys > 0){
            return true;         
        } else{
            return false;
        }
    }

}
