using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTideSpawner : MonoBehaviour
{
    public Rigidbody2D trashTide;
    Vector3 spawningPosition;
    public void SpawnTide()
    {
        for (int i = 0; i < 250; i++)
        {
            spawningPosition = new Vector3(transform.position.x, Random.Range(-2f, 3.5f), 0);

            Rigidbody2D clone;
            clone = Instantiate(trashTide, spawningPosition, transform.rotation);
            clone.velocity = new Vector2(Random.Range(-2f, -6f), 0f);
        }
    }
}
