using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwarmSpawner : MonoBehaviour
{
    public Rigidbody2D droneSwarm;
    public TrashNet trashNet;
    Vector3 spawningPosition;
    public void SpawnSwarm()
    {
        if (trashNet.plasticTrashAmt > 19 && trashNet.metalTrashAmt > 19 && trashNet.glassTrashAmt > 19)
        {
            for (int i = 0; i < 50; i++)
            {
                spawningPosition = new Vector3(transform.position.x, Random.Range(-2f, 3.5f), 0);

                Rigidbody2D clone;
                clone = Instantiate(droneSwarm, spawningPosition, transform.rotation);
                clone.velocity = new Vector2(Random.Range(5f, 10f), 0f);
            }
            trashNet.plasticTrashAmt -= 20;
            trashNet.metalTrashAmt -= 20;
            trashNet.glassTrashAmt -= 20;
        }
    }
}
