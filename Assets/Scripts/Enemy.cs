using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public float triggerLenght = 1;
    public float chaseLenght = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new  Collider2D[10];

    protected override void Start(){
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate(){

        if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght){
            if(Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght){
                chasing = true;
            }
            
            if(chasing){
                if(!collidingWithPlayer){
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
                else{
                    UpdateMotor(startingPosition - transform.position);
                }
            } else{
                UpdateMotor(startingPosition - transform.position);
                chasing = false;
            }
        }

        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);

        // Iterar sobre los colliders que colisionan con este objeto
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            // Llamar a la función OnCollide() para manejar la colisión con el collider específico
            if(hits[i].tag == "fighter" && hits[i].name == "Player"){
                collidingWithPlayer = true;
            }
            hits[i] = null;
        }
        
    }
}
