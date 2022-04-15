using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFishSpawner : MonoBehaviour
{

    public Rigidbody2D turtle;
    public Rigidbody2D[] smallFishList;
    public Rigidbody2D[] largeFishList;

    float top;
    float bottom;
    Vector3 spawningPosition;

    public Rigidbody2D[] fishSchools;
    private GameObject[] myGameObjects;

    void Start()
    {
        top = this.transform.Find("RightTop").position.y;
        bottom = this.transform.Find("RightBottom").position.y;

        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));

        //smaller chance for large fish species
        int largeOrSmall = Random.Range(1, 5);
        
        if (largeOrSmall == 1)
        {
            int fishChoice = Random.Range(1, largeFishList.Length + 1);

            spawningPosition = new Vector3(transform.position.x, Random.Range(bottom, top), 0f);
            Rigidbody2D clone;
            clone = Instantiate(largeFishList[fishChoice - 1], spawningPosition, transform.rotation);
            clone.velocity = new Vector2(Random.Range(-3, -8), 0f);
        }

        else if (largeOrSmall > 1)
        {
            int fishChoice = Random.Range(1, smallFishList.Length + 1);

            spawningPosition = new Vector3(transform.position.x, Random.Range(bottom, top), 0f);

            Rigidbody2D clone;
            clone = Instantiate(smallFishList[fishChoice - 1], spawningPosition, transform.rotation);
            clone.velocity = new Vector2(Random.Range(-3, -8), 0f);
        }

        //trurtle spawning
        if (GameObject.FindGameObjectWithTag("Turtle") == null)
        {
            int turtleChance = Random.Range(0, 100);
            spawningPosition = new Vector3(transform.position.x, Random.Range(bottom, top), 0f);

            if (turtleChance > 40)
            {
                Rigidbody2D cloneT;
                cloneT = Instantiate(turtle, spawningPosition, transform.rotation);
                cloneT.velocity = new Vector2(Random.Range(-1, -2), 0);
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
                clone1.velocity = new Vector2(Random.Range(-3, -6), 0f);

            }
            else if (fishSchoolChance >= 33 && fishSchoolChance <= 66)
            {
                Rigidbody2D clone2;
                clone2 = Instantiate(fishSchools[1], spawningPosition, transform.rotation);
                clone2.velocity = new Vector2(Random.Range(-3, -6), 0f);
            }
            else if (fishSchoolChance > 66)
            {
                Rigidbody2D clone3;
                clone3 = Instantiate(fishSchools[2], spawningPosition, transform.rotation);
                clone3.velocity = new Vector2(Random.Range(-3, -6), 0f);
            }

        }

        yield return new WaitForSeconds(Random.Range(4, 5));
        StartCoroutine(Spawn());
    }
}
