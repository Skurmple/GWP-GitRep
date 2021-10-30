using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFishSpawner : MonoBehaviour
{

    public Rigidbody2D fish;
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
        float randomSize = Random.Range(0.25f, 0.5f);
        clone = Instantiate(fish, spawningPosition, transform.rotation);
        clone.transform.localScale = new Vector3(-randomSize, randomSize, randomSize);
        clone.velocity = new Vector2(Random.Range(-5, -10), 0f);

        yield return new WaitForSeconds(Random.Range(2, 3));
        StartCoroutine(Spawn());
    }
}
