using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFishSpawner : MonoBehaviour
{
    //Variable initialisation to store values such as copies of each kind of fish, and where to spawn them
    public Rigidbody2D turtle;
    public Rigidbody2D[] smallFishList;
    public Rigidbody2D[] largeFishList;

    public Rigidbody2D[] fishSchools;
    private GameObject[] myGameObjects;

    float top;
    float bottom;
    Vector3 spawningPosition;


    //Start is called when the game starts
    void Start()
    {
        top = this.transform.Find("LeftTop").position.y;
        bottom = this.transform.Find("LeftBottom").position.y;

        //Starts the looping coroutine that spawns the fish
        StartCoroutine(Spawn());
    }

    //Coroutine that spawns a fish each time it is called
    IEnumerator Spawn()
    {
        //Waits 1.5f before each spawn
        yield return new WaitForSeconds(Random.Range(1, 2));

        int largeOrSmall = Random.Range(1, 5);

        if (largeOrSmall == 1)
        {
            int fishChoice = Random.Range(1, largeFishList.Length + 1);

            spawningPosition = new Vector3(transform.position.x, Random.Range(bottom, top), 0f);
            Rigidbody2D clone;
            clone = Instantiate(largeFishList[fishChoice - 1], spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(clone.transform.localScale.x * -1, clone.transform.localScale.y, clone.transform.localScale.z);
            clone.velocity = new Vector2(Random.Range(3, 8), 0f);
        }

        else if (largeOrSmall > 1)
        {
            int fishChoice = Random.Range(1, smallFishList.Length + 1);

            spawningPosition = new Vector3(transform.position.x, Random.Range(bottom, top), 0f);

            Rigidbody2D clone;
            clone = Instantiate(smallFishList[fishChoice - 1], spawningPosition, transform.rotation);
            clone.transform.localScale = new Vector3(clone.transform.localScale.x * -1, clone.transform.localScale.y, clone.transform.localScale.z);
            clone.velocity = new Vector2(Random.Range(3, 8), 0f);
        }

        //Checks to see if there is currently a sea turtle on the screen, and if not, enters the if statement
        if (GameObject.FindGameObjectWithTag("Turtle") == null)
        {
            //Creates a random number to determine whether or not a turtle actually spawns
            int turtleChance = Random.Range(0, 100);

            //Sets the position of where to spawn the turtle
            spawningPosition = new Vector3(transform.position.x, Random.Range(bottom, top), 0f);

            //Makes it a 60% chance to spawn a turtle
            if (turtleChance > 40)
            {
                //Instantiates the turtle and sets its speed
                Rigidbody2D cloneT;
                cloneT = Instantiate(turtle, spawningPosition, transform.rotation);
                cloneT.transform.localScale = new Vector3(cloneT.transform.localScale.x*-1, cloneT.transform.localScale.y, cloneT.transform.localScale.z);
                cloneT.velocity = new Vector2(Random.Range(1, 2), 0);
            }

        }

        //by Vojta
        myGameObjects = GameObject.FindGameObjectsWithTag("FishSchool");

        if (myGameObjects.Length < 3)
        {
            int fishSchoolChance = Random.Range(0, 100);

            spawningPosition = new Vector3(transform.position.x, Random.Range(0.5f, 22), 0);

            if (fishSchoolChance < 33)
            {
                Rigidbody2D clone1;
                clone1 = Instantiate(fishSchools[0], spawningPosition, transform.rotation);
                clone1.transform.localScale = new Vector3(-1, 1, 1);
                clone1.velocity = new Vector2(Random.Range(3, 6), 0f);

            }
            else if (fishSchoolChance >= 33 && fishSchoolChance <= 66)
            {
                Rigidbody2D clone2;
                clone2 = Instantiate(fishSchools[1], spawningPosition, transform.rotation);
                clone2.transform.localScale = new Vector3(-1, 1, 1);
                clone2.velocity = new Vector2(Random.Range(3, 6), 0f);
            }
            else if (fishSchoolChance > 66)
            {
                Rigidbody2D clone3;
                clone3 = Instantiate(fishSchools[2], spawningPosition, transform.rotation);
                clone3.transform.localScale = new Vector3(-1, 1, 1);
                clone3.velocity = new Vector2(Random.Range(3, 6), 0f);
            }

        }
            //Waits randomly between 1 and 3 seconds before trying to spawn another fish
            yield return new WaitForSeconds(Random.Range(4, 5));
        StartCoroutine(Spawn());
    }
}
