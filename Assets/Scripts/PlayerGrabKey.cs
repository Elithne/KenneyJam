using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabKey : MonoBehaviour
{
    private int keys;

    private void Awake(){
        keys = 0;
    }

    public void AddKey(){
        keys++;
        Debug.Log(keys);
    }

    public void RemoveKey(){
        if(keys >= 0){
            keys--;
        }       
    }

    public bool HasKey(){
        if(keys > 0){
            return true;         
        } else{
            return false;
        }
    }

}
