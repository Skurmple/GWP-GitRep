using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFishSpawner : MonoBehaviour
{
    //Variable initialisation to store values such as copies of each kind of fish, and where to spawn them
    public Rigidbody2D fish;
    public Rigidbody2D nautilus;
    public Rigidbody2D turtle;
    Vector3 spawningPosition;


    //Start is called when the game starts
    void Start()
    {
        //Starts the looping coroutine that spawns the fish
        StartCoroutine(Spawn());
    }

    //Coroutine that spawns a fish each time it is called
    IEnumerator Spawn()
    {
        //Waits 1.5f before each spawn
        yield return new WaitForSeconds(1.5f);

        //Creates a random number to decide which kind of fish is spawned
        int fishChoice = Random.Range(0, 100);

        //Sets the position to spawn the fish to a set position with a random height
        spawningPosition = new Vector3(transform.position.x, Random.Range(18, 22), 0);

        //Uses the randomly generated number and checks to see what kind of fish should be made
        if (fishChoice < 70)
        {
            //Instantiates the fish with slight size variation, and sets it off with a slightly randomised velocity
            Rigidbody2D clone;
            float randomSize = Random.Range(0.2f, 0.4f);
            clone = Instantiate(fish, spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            clone.velocity = new Vector2(Random.Range(5, 10), 0f);
        }

        //Else statement to spawn the other kind of fish, which is a nautilus
        else
        {
            //Instantiates the nautilus, and sets it off with a slightly randomised velocity
            Rigidbody2D clone;
            clone = Instantiate(nautilus, spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            clone.velocity = new Vector2(Random.Range(2, 6), 0f);
        }

        //Checks to see if there is currently a sea turtle on the screen, and if not, enters the if statement
        if (GameObject.FindGameObjectWithTag("Turtle") == null)
        {
            //Creates a random number to determine whether or not a turtle actually spawns
            int turtleChance = Random.Range(0, 100);

            //Sets the position of where to spawn the turtle
            spawningPosition = new Vector3(transform.position.x, -2.5f, 0);

            //Makes it a 25% chance to spawn a turtle
            if (turtleChance > 75)
            {
                //Instantiates the turtle and sets its speed
                Rigidbody2D clone;
                clone = Instantiate(turtle, spawningPosition, transform.rotation);
                clone.transform.localScale = new Vector3(-0.30f, 0.30f, 0.30f);
            }
        }

        //Waits randomly between 1 and 3 seconds before trying to spawn another fish
        yield return new WaitForSeconds(Random.Range(1, 4));
        StartCoroutine(Spawn());
    }
}
