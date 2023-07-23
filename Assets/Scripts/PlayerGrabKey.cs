using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabKey : MonoBehaviour
{
    private int keys;

    public void Awake(){
        
    }

    public void AddKey(){
        keys++;
        Debug.Log(keys);
    }

    public void RemoveKey(){
        if(keys > 0){
            keys--;
            Debug.Log(keys);
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
