using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite openChest;
    public PlayerGrabKey playerGrabKey;

    public int coins = 5;
    protected override void OnCollect(){
        if(Input.GetKeyDown(KeyCode.F)){
            if(!collected){
                GetComponent<SpriteRenderer>().sprite = openChest;
                playerGrabKey.addKey();
                collected = true;
            }
        }  
    }
}
