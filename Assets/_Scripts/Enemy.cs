using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;  // the speed in m/s
    public float fireRate = 0.3f; // Seconds/shot (Unused)
    public float health = 10;
    public float score = 100; // Points earned for destroy this

    private BoundsCheck bndCheck;

    
    void Awake()    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    // this is a Property: A method that acts like a field
    public Vector3 pos  {
        get {
            return (this.transform.position);
        }
        set {
            this.transform.position = value;
        }
    }
    // Update is called once per frame
    void Update()   {
        Move();

        if (bndCheck != null && !bndCheck.offDown)  {
            //if ( bndCheck != null && !bndCheck.isOnScreen )  {
            // check to make sure it's gone off the bottom of the screen
            if ( pos.y <-bndCheck.camHeight - bndCheck.radius )  {
                // We're off the bottom, so destroy this GameObject
                Destroy(gameObject);
            }
        }
    } 

    public virtual void Move() {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
    void OnCollisionEnter( Collision coll) {
            GameObject otherGO = coll.gameObject;
        Debug.Log("Collided!!!");
            if ( otherGO.tag == "ProjectileHero" ) {
                Destroy( otherGO ); // destroy the projectile 
                Destroy(gameObject);  //destroy the enemy gameobject
            } else {
                print("Enemy hit by non-ProjectileHero: " + otherGO.name);
            }
    }
}

