using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwarmSpawner : MonoBehaviour
{
    public Rigidbody2D droneSwarm;
    Vector3 spawningPosition;
    public void SpawnSwarm()
    {
        for (int i = 0; i < 50; i++)
        {
            spawningPosition = new Vector3(transform.position.x, Random.Range(-2, 4), 0);

            Rigidbody2D clone;
            clone = Instantiate(droneSwarm, spawningPosition, transform.rotation);
            clone.velocity = new Vector2(Random.Range(5, 10), 0f);
        }
    }
}
