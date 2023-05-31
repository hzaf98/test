using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle: MonoBehaviour
{
    HeroMovement heroMovement;
    void Start()
    {
        //looks for an object of the type Heromovement which is attached to the player and sets this variable to that
        heroMovement = GameObject.FindObjectOfType<HeroMovement>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Kill hero
        if (collision.gameObject.name == "Hero")
        {
            heroMovement.Die();
        }
        
    }
    void Update()
    {
        
    }
}
