using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrashSpawner : MonoBehaviour
{

    public Rigidbody2D trash;
    Vector3 spawningPosition;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        spawningPosition = new Vector3(transform.position.x, Random.Range(-2, 2), 0);
    }
    //spawning food between 1-3 seconds
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.5f);
        Rigidbody2D clone;
        clone = Instantiate(trash, spawningPosition, transform.rotation);
        clone.velocity = new Vector2(Random.Range(3, 5), 0f);

        yield return new WaitForSeconds(Random.Range(2, 4));
        StartCoroutine(Spawn());
    }
}
