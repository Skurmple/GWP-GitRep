using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFishSpawner : MonoBehaviour
{

    public Rigidbody2D fish;
    public Rigidbody2D nautilus;
    public Rigidbody2D turtle;
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
            float randomSize = Random.Range(0.25f, 0.5f);
            clone = Instantiate(fish, spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            clone.velocity = new Vector2(Random.Range(5, 10), 0f);
        }
        else
        {
            Rigidbody2D clone;
            clone = Instantiate(nautilus, spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(0.20f, 0.20f, 0.20f);
            clone.velocity = new Vector2(Random.Range(2, 6), 0f);
        }

        if (GameObject.FindGameObjectWithTag("Turtle") == null)
        {
            int turtleChance = Random.Range(0, 100);
            spawningPosition = new Vector3(transform.position.x, -2.5f, 0);

            if (turtleChance > 75)
            {
                Rigidbody2D clone;
                clone = Instantiate(turtle, spawningPosition, transform.rotation);
                clone.transform.localScale = new Vector3(-0.30f, 0.30f, 0.30f);
            }
        }

        yield return new WaitForSeconds(Random.Range(1, 4));
        StartCoroutine(Spawn());
    }
}
