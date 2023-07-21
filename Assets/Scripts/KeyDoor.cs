using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : Collidable

{
    public PlayerGrabKey playerGrabKey;
    public GameObject door;


    protected override void OnCollide(Collider2D col){ 
        if(col.name == "Player" && playerGrabKey.hasKey()){
            Debug.Log("I open the door");
            //door.SetActive(false);
        }
    }
}
