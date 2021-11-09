using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwarmDrone : MonoBehaviour
{
    //Small script for each drone in the drone swarm so that they can destroy trash

    //Collision detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks to see if the drone has collided with Trash or a Pile
        if (collision.gameObject.tag.Contains("Trash") || collision.gameObject.tag == "Pile")
        {
            //Destroys whatever it collided with
            Destroy(collision.gameObject);
        }
    }
}
