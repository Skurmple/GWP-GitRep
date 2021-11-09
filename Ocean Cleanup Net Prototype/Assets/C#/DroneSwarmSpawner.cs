using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwarmSpawner : MonoBehaviour
{
    //Variable initalisation to store values such as the position where the drone swarm should spawn
    public Rigidbody2D droneSwarm;
    public TrashNet trashNet;
    Vector3 spawningPosition;

    //Method to be called from elsewhere, to spawn the drone swarm
    public void SpawnSwarm()
    {
        //Makes sure the player has enough trash to summon the swarm
        if (trashNet.plasticTrashAmt >= 20 && trashNet.metalTrashAmt >= 20 && trashNet.glassTrashAmt >= 20)
        {
            //For loop to spawn each drone, up to 50 drones
            for (int i = 0; i < 50; i++)
            {
                //Sets the position to spawn in to a random height off the left side of the sreen
                spawningPosition = new Vector3(transform.position.x, Random.Range(-2f, 3.5f), 0);

                //Instantiates each drone, and sets it moving
                Rigidbody2D clone;
                clone = Instantiate(droneSwarm, spawningPosition, transform.rotation);
                clone.velocity = new Vector2(Random.Range(5f, 10f), 0f);
            }
        }
    }
}
