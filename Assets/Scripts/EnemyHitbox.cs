using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int damage = 1;
    public float pushForce= 4;

    protected override void OnCollide(Collider2D col){
        if(col.tag =="fighter" && col.name =="Player"){
            Damage dmg = new Damage {
                damageAmount = damage, 
                origin = transform.position, 
                pushForce = pushForce
            };
            
            col.SendMessage("ReceiveDamage",dmg);
        }
    }
}
