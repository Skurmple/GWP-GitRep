using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFishSpawner : MonoBehaviour
{

    public Rigidbody2D salmon;
    public Rigidbody2D redFish;
    public Rigidbody2D ling;
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
        yield return new WaitForSeconds(2f);

        int fishChoice = Random.Range(0, 100);
        spawningPosition = new Vector3(transform.position.x, Random.Range(8, 23), 0);

        //Uses the randomly generated number and checks to see what kind of fish should be made
        if (fishChoice < 33)
        {
            //Instantiates the fish with slight size variation, and sets it off with a slightly randomised velocity
            Rigidbody2D clone;
            clone = Instantiate(salmon, spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            clone.velocity = new Vector2(Random.Range(-5, -10), 0f); ;
        }

        //Else statement to spawn the other kind of fish, which is a nautilus
        else if (fishChoice >= 33 && fishChoice < 66)
        {
            //Instantiates the nautilus, and sets it off with a slightly randomised velocity
            Rigidbody2D clone;
            clone = Instantiate(redFish, spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            clone.velocity = new Vector2(Random.Range(-5, -10), 0f);
        }

        else if (fishChoice > 66)
        {
            Rigidbody2D clone;
            clone = Instantiate(ling, spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            clone.velocity = new Vector2(Random.Range(-5, -10), 0f);
        }

        yield return new WaitForSeconds(Random.Range(3, 4));
        StartCoroutine(Spawn());
    }
}
