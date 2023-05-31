using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;//90degrees per second
    private void OnTriggerEnter(Collider other)
    {
        //Checks if other gameobject is an obstacle, only obstacle contain component obstacle
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        //Check that other object that we collided with is the player
        if(other.gameObject.name != "Hero")
        {
            return;
        }
        //Add to player score
        GameManager.inst.IncrementScore();
        //Destroy coin
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime); //90 degrees rotation along z axis every second
    }
}
