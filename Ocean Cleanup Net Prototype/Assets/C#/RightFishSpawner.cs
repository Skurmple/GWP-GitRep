using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFishSpawner : MonoBehaviour
{

    public Rigidbody2D fish;
    public Rigidbody2D nautilus;
    Vector3 spawningPosition;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        
    }
    //spawning food between 1-3 seconds
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.5f);

        int fishChoice = Random.Range(0, 100);
        spawningPosition = new Vector3(transform.position.x, Random.Range(-2, 2), 0);

        if (fishChoice < 70)
        {
            Rigidbody2D clone;
            float randomSize = Random.Range(0.2f, 0.4f);
            clone = Instantiate(fish, spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(-randomSize, randomSize, randomSize);
            clone.velocity = new Vector2(Random.Range(-5, -10), 0f);
        }
        else
        {
            Rigidbody2D clone;
            clone = Instantiate(nautilus, spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
            clone.velocity = new Vector2(Random.Range(-2, -6), 0f);
        }

        yield return new WaitForSeconds(Random.Range(2, 3));
        StartCoroutine(Spawn());
    }
}
